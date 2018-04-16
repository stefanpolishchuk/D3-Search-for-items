using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace D3_Search_for_items
{
    public partial class MainForm : Form
    {
        private const string apiKey = "e4exz4hs3gdwy7gj4mwez7eh57xmzhq3";
        private const short pictureSize = 64;
        private const int numberOfActiveSkills = 26;
        private const int numberOfPassiveSkills = 20;
        public const string iconsDirectoryName = "icons";
        public const string xmlsDirectoryName = "data";

        private Dictionary<string, CharacterInfo> charactersInfo;
        private Dictionary<string, List<SkillsInfo>> skillsInfo;
        private bool skillsIconsLoadingFlag = true;
        private List<string> charactersSlug;
        private SimpleLogger log;

        public MainForm()
        {
            InitializeComponent();

            charactersSlug = new List<string>
            {
                "wizard",
                "necromancer",
                "barbarian",
                "crusader",
                "witch-doctor",
                "demon-hunter",
                "monk"
            };

            charactersInfo = new Dictionary<string, CharacterInfo>();
            skillsInfo = new Dictionary<string, List<SkillsInfo>>();
            log = new SimpleLogger(true);

            CheckDiractoriesExist();
            GetCharactersInfo();

            BackgroundWorker bwCheckCharactersIcons = new BackgroundWorker();
            bwCheckCharactersIcons.DoWork += CheckCharactersImages;
            bwCheckCharactersIcons.RunWorkerAsync();
            bwCheckCharactersIcons.RunWorkerCompleted += CreateCharactersIcons;

            BackgroundWorker bwCheckSkillsIcons = new BackgroundWorker();
            bwCheckSkillsIcons.DoWork += CheckSkillsImages;
            bwCheckSkillsIcons.RunWorkerAsync();
            bwCheckSkillsIcons.RunWorkerCompleted += CreateSkillsPictureBoxes;
        }

        private void CheckDiractoriesExist()
        {
            if (!Directory.Exists(iconsDirectoryName))
            {
                Directory.CreateDirectory(iconsDirectoryName);
            }

            if (!Directory.Exists(xmlsDirectoryName))
            {
                Directory.CreateDirectory(xmlsDirectoryName);
            }
        }

        private void GetCharactersInfo()
        {
            try
            {
                for (int i = 0; i < charactersSlug.Count; ++i)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    string characterSlug = charactersSlug[i];
                    string xmlFilePath = $"{xmlsDirectoryName}/{characterSlug}.xml";

                    if (!File.Exists(xmlFilePath))
                    {
                        LoadCharacterData(characterSlug, xmlFilePath);
                    }

                    xmlDocument.Load(xmlFilePath);
                    string name = xmlDocument.SelectSingleNode("root/name").InnerText;
                    string icon = xmlDocument.SelectSingleNode("root/icon").InnerText;
                    charactersInfo.Add(characterSlug, new CharacterInfo(name, icon));
                    GetSkillsInfo(characterSlug, xmlDocument);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void LoadCharacterData(string characterSlug, string filePath)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;

                    string url = $"https://eu.api.battle.net/d3/data/hero/{characterSlug}?locale=ru_RU&apikey={apiKey}";

                    var response = webClient.DownloadString(url);
                    var xmlDocument = JsonConvert.DeserializeXmlNode(response, "root");
                    xmlDocument.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void GetSkillsInfo(string characterSlug, XmlDocument xmlDocument)
        {
            List<SkillsInfo> list = new List<SkillsInfo>();
            list = GetSkillsByType("active", xmlDocument);
            list.AddRange(GetSkillsByType("passive", xmlDocument));
            skillsInfo.Add(characterSlug, list);
        }

        private List<SkillsInfo> GetSkillsByType(string type, XmlDocument xmlDocument)
        {
            List<SkillsInfo> list = new List<SkillsInfo>();

            try
            {
                var skillsXml = xmlDocument.SelectNodes($"root/skills/{type}");

                foreach (XmlNode item in skillsXml)
                {
                    string slug = item.SelectSingleNode("slug").InnerText;
                    string name = item.SelectSingleNode("name").InnerText;
                    string icon = item.SelectSingleNode("icon").InnerText;
                    string description = item.SelectSingleNode("description").InnerText;
                    list.Add(new SkillsInfo(type, slug, name, icon, description));
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

            return list;
        }

        private void CheckCharactersImages(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < charactersSlug.Count; ++i)
                {
                    string characterIcon = charactersInfo[charactersSlug[i]].Icon;
                    string fileName = $"{iconsDirectoryName}/{characterIcon}.png";

                    if (!File.Exists(fileName))
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            var url = new Uri($"http://media.blizzard.com/d3/icons/portraits/64/{characterIcon}.png");
                            webClient.DownloadFile(url, fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void CheckSkillsImages(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < charactersSlug.Count; ++i)
                {
                    List<SkillsInfo> listOfSkills = skillsInfo[charactersSlug[i]];

                    foreach (SkillsInfo item in listOfSkills)
                    {
                        string fileName = $"{iconsDirectoryName}/{item.Icon}.png";

                        if (!File.Exists(fileName))
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                var url = new Uri($"http://media.blizzard.com/d3/icons/skills/64/{item.Icon}.png");
                                webClient.DownloadFile(url, fileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void CreateCharactersIcons(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < charactersSlug.Count; ++i)
                {
                    string icon = charactersInfo[charactersSlug[i]].Icon;
                    string name = "pictureBox_" + charactersSlug[i];
                    int xPosition = 8 + i * 72;
                    int yPosition = 8;

                    PictureBox pictureBox = new PictureBox
                    {
                        BackColor = Color.Black,
                        Size = new Size(pictureSize, pictureSize),
                        Location = new Point(xPosition, yPosition),
                        Name = name,
                        Tag = "Character"
                    };

                    pictureBox.MouseHover += PictureBox_MouseEnter;
                    pictureBox.Click += PictureBox_Click;
                    string fileName = $"{iconsDirectoryName}/{icon}.png";
                    pictureBox.Image = Image.FromFile(fileName);

                    Controls.Add(pictureBox);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void CreateSkillsPictureBoxes(object sender, EventArgs e)
        {
            skillsIconsLoadingFlag = false;
            labelLoadingImages.Visible = false;
            CreateSkillsPictureBoxes(numberOfActiveSkills, true);
            CreateSkillsPictureBoxes(numberOfPassiveSkills, false);
        }

        private void CreateSkillsPictureBoxes(int numberOfPictureBoxes, bool type)
        {
            try
            {
                int currentRow = 0;
                int currentCol = 0;
                for (int i = 0; i < numberOfPictureBoxes; ++i)
                {
                    currentRow = i / 7;

                    int xPosition = 2 + currentCol * 72;
                    int yPosition = 3 + currentRow * 72;

                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(pictureSize, pictureSize),
                        Location = new Point(xPosition, yPosition),
                        Name = "pictureBox_" + i
                    };

                    pictureBox.MouseHover += PictureBox_MouseEnter;
                    pictureBox.Click += PictureBox_Click;

                    if (type)
                    {
                        activeSkills.Controls.Add(pictureBox);
                    }
                    else
                    {
                        passiveSkills.Controls.Add(pictureBox);
                    }

                    currentCol = currentCol < 6 ? currentCol + 1 : 0;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void SetSkillsIcons(string characterSlug)
        {
            List<SkillsInfo> list = skillsInfo[characterSlug];
            List<SkillsInfo> activeSkillsList = list.Where(e => e.Type == "active").ToList();
            List<SkillsInfo> passiveSkillsList = list.Where(e => e.Type == "passive").ToList();

            ClearPictureBoxes(numberOfActiveSkills, activeSkills);
            ClearPictureBoxes(numberOfPassiveSkills, passiveSkills);

            SetIconToPictureBox(activeSkillsList, activeSkills);
            SetIconToPictureBox(passiveSkillsList, passiveSkills);
        }

        private void SetIconToPictureBox(List<SkillsInfo> list, TabPage tabPage)
        {
            try
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    var item = list[i];

                    if (tabPage.Controls["pictureBox_" + i] is PictureBox pictureBox)
                    {
                        pictureBox.Tag = item;
                        pictureBox.Image = Image.FromFile($@"{iconsDirectoryName}/{item.Icon}.png");
                        pictureBox.BackColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void ClearPictureBoxes(int numberOfPictureBoxes, TabPage tabPage)
        {
            for (int i = 0; i < numberOfPictureBoxes; ++i)
            {
                if (tabPage.Controls["pictureBox_" + i] is PictureBox pictureBox)
                {
                    pictureBox.BackColor = Color.Empty;
                    pictureBox.Image = null;
                }
            }
        }

        public void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && !skillsIconsLoadingFlag && pictureBox.Image != null)
            {
                if (pictureBox.Tag.ToString() == "Character")
                {
                    metkaCharacter.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 66);
                    metkaCharacter.Visible = true;
                    SetSkillsIcons(pictureBox.Name.Split('_')[1]);
                    ClearFields();
                }
                else
                {
                    Label label;
                    var pictureDetail = (SkillsInfo)pictureBox.Tag;

                    if (pictureDetail.Type == "active")
                    {
                        label = metkaActiveSkill;
                        metkaPassiveSkill.Visible = false;
                    }
                    else
                    {
                        label = metkaPassiveSkill;
                        metkaActiveSkill.Visible = false;
                    }

                    label.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 65);
                    label.Visible = true;

                    labelSkillName.Text = pictureDetail.Name;
                    labelSkillDescription.Text = pictureDetail.Description;
                }
            }
        }

        private void ClearFields()
        {
            metkaActiveSkill.Visible = false;
            metkaPassiveSkill.Visible = false;
            labelSkillName.Text = "";
            labelSkillDescription.Text = "";
        }

        private void SetFields(PictureBox pictureBox)
        {
            Label label;
            var pictureDetail = (SkillsInfo)pictureBox.Tag;

            if (pictureDetail.Type == "active")
            {
                label = metkaActiveSkill;
                metkaPassiveSkill.Visible = false;
            }
            else
            {
                label = metkaPassiveSkill;
                metkaActiveSkill.Visible = false;
            }

            label.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 65);
            label.Visible = true;

            labelSkillName.Text = pictureDetail.Name;
            labelSkillDescription.Text = pictureDetail.Description;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && !skillsIconsLoadingFlag && pictureBox.Image != null)
            {
                pictureBox.Cursor = Cursors.Hand;
            }
        }
    }
}
