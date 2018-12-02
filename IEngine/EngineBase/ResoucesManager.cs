using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


/*************************************************************
** MadeBy		：			IceCubePill						**
** Time			:			 2018/10/20 17:17:40							**
** Description	：											**
**************************************************************/
namespace IEngine.EngineBase
{
    public class ResoucesManager : SingleType<ResoucesManager>
    {


        private string m_resourcesRoot;
        private Dictionary<string, string> m_nameDic = new Dictionary<string, string>();
        private readonly Dictionary<string, Texture2D> m_textureDic = new Dictionary<string, Texture2D>();
        private readonly Dictionary<string, SoundEffect> m_soundDic = new Dictionary<string, SoundEffect>();

        public ContentManager content;
        public string resourcesRoot => m_resourcesRoot;



        public Texture2D GetTexture(string name)
        {
            return m_textureDic[name] ?? (m_textureDic[name] = content.Load<Texture2D>(name));
        }

        public SoundEffect GetSoundEffect(string name)
        {
            return m_soundDic[name] ?? (m_soundDic[name] = content.Load<SoundEffect>(name));
        }

        internal override void OnConstruct(Game1 game)
        {
            content = game.Content;

            //构建资源管理表
            m_resourcesRoot = AppDomain.CurrentDomain.BaseDirectory + @"/Content.mgcb";
            if (!File.Exists(m_resourcesRoot))
                DebugManager.Debug(DebugType.Error, "Please move the .mfcb file to the exe root path");
            ReadResourcesList();



        }

        public void ReadResourcesList()
        {
            using (StreamReader sr = new StreamReader(m_resourcesRoot))
            {

                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (s.Contains("#begin"))
                    {
                        s = s.Replace("#begin ", "");
                        string[] fname = s.Split('.');
                        switch (fname[1])
                        {
                            case "jpg":
                            case "png":
                            case "bmp":
                                if (m_textureDic.ContainsKey(fname[0]))
                                {
                                    DebugManager.Debug(DebugType.Error, "Resources has exsited! Please cheack the name of : " + s);
                                    return;
                                }
                                m_textureDic.Add(fname[0], null);
                                break;
                            case "wav":
                                if (m_soundDic.ContainsKey(fname[0]))
                                {
                                    DebugManager.Debug(DebugType.Error, "Resources has exsited! Please cheack the name of : " + s);
                                    return;
                                }
                                m_soundDic.Add(fname[0], null);
                                break;
                        }
                    }
                }

            }

        }
        /// <summary>
        /// 递归遍历所以子目录，弃用的
        /// </summary>
        /// <param name="di"></param>
        //private void GetAllFile(DirectoryInfo di)
        //{
        //    foreach (var file in di.GetFiles())
        //    {
        //        string s = file.FullName.Replace(rawResouce, "");
        //        string name = s.Replace(file.Extension, "");
        //       
        //        switch (file.Extension)
        //        {
        //            case ".jpg":
        //            case ".png":
        //            case ".bmp":
        //                if (m_textureDic.ContainsKey(name))
        //                {
        //                    DebugManager.Debug("Resources has exsited! Please cheack the name of : " + s);
        //                    return;
        //                }
        //                m_textureDic.Add(name,null);
        //                break;
        //            case ".wav":
        //                if (m_soundDic.ContainsKey(name))
        //                {
        //                    DebugManager.Debug("Resources has exsited! Please cheack the name of : " +s);
        //                    return;
        //                }
        //                m_soundDic.Add(name, null);
        //                break;
        //        }
        //    }
        //    if (di.GetDirectories().Length>0)
        //        foreach (var direct in di.GetDirectories())
        //        {
        //            GetAllFile(direct);
        //        }
        //}
    }
}
