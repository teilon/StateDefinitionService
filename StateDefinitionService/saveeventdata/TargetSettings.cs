using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace StateDefinitionService.saveeventdata
{
    public class TargetSettings : ConfigurationSection
    {
        [ConfigurationProperty("Target", IsRequired = true)]
        public TargetElement Target
        {
            get { return (TargetElement)this["Target"]; }
            set { this["Target"] = value; }
        }
        [ConfigurationProperty("Map", IsRequired = true)]
        public TargetElement Map
        {
            get { return (TargetElement)this["Map"]; }
            set { this["Map"] = value; }
        }
    }

    public class TargetElement : ConfigurationElement
    {

        [ConfigurationProperty("url", DefaultValue = "", IsRequired = true)]
        //[IntegerValidator(MinValue = 3, MaxValue = 30, ExcludeRange = false)]
        public string url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }        
    }
    public class Config
    {

        /// <summary>
        /// скроем конструктор от любопытных программеров
        /// </summary>
        public Config() { }

        /// <summary>
        /// наименование раздела конфигурации
        /// </summary>
        private const string CONFIGGROUPNAME = "ServiceSettingsGroup/";

        /// <summary>
        /// наименование секции
        /// </summary>
        private const string CONFIGSECTIONNAME = "TargetSettings";   

        /// <summary>
        /// Чтение раздела конфигурации целиком
        /// </summary>
        /// <returns></returns>
        internal static TargetSettings Get()
        {
            var config = (TargetSettings)ConfigurationManager
                 .GetSection(String.Concat(CONFIGSECTIONNAME));
            return config;
        } 
    }
}