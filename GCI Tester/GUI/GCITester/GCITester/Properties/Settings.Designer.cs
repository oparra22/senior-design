﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//EA NOTE: This file was copied straight from the previous section changing 10 to 11
namespace GCITester.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")] //This value was changed to 11 from 10
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM5")]
        public string ComPort
        {
            get
            {
                return ((string)(this["ComPort"]));
            }
            set
            {
                this["ComPort"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9600")]
        public int BaudRate
        {
            get
            {
                return ((int)(this["BaudRate"]));
            }
            set
            {
                this["BaudRate"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int DataBits
        {
            get
            {
                return ((int)(this["DataBits"]));
            }
            set
            {
                this["DataBits"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("One")]
        public global::System.IO.Ports.StopBits StopBits
        {
            get
            {
                return ((global::System.IO.Ports.StopBits)(this["StopBits"]));
            }
            set
            {
                this["StopBits"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("None")]
        public global::System.IO.Ports.Parity Parity
        {
            get
            {
                return ((global::System.IO.Ports.Parity)(this["Parity"]));
            }
            set
            {
                this["Parity"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public double VoltageReference
        {
            get
            {
                return ((double)(this["VoltageReference"]));
            }
            set
            {
                this["VoltageReference"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int Learn_DefaultIterations
        {
            get
            {
                return ((int)(this["Learn_DefaultIterations"]));
            }
            set
            {
                this["Learn_DefaultIterations"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int Learn_DefaultNumberOfParts
        {
            get
            {
                return ((int)(this["Learn_DefaultNumberOfParts"]));
            }
            set
            {
                this["Learn_DefaultNumberOfParts"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-20")]
        public double LifetimeLimit_DefaultLowerRange
        {
            get
            {
                return ((double)(this["LifetimeLimit_DefaultLowerRange"]));
            }
            set
            {
                this["LifetimeLimit_DefaultLowerRange"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public double LifetimeLimit_DefaultUpperRange
        {
            get
            {
                return ((double)(this["LifetimeLimit_DefaultUpperRange"]));
            }
            set
            {
                this["LifetimeLimit_DefaultUpperRange"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public int ProductionLimit_DefaultSigma
        {
            get
            {
                return ((int)(this["ProductionLimit_DefaultSigma"]));
            }
            set
            {
                this["ProductionLimit_DefaultSigma"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int Learn_SigmaRangeForFlyers
        {
            get
            {
                return ((int)(this["Learn_SigmaRangeForFlyers"]));
            }
            set
            {
                this["Learn_SigmaRangeForFlyers"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int Lifetime_DefaultIterations
        {
            get
            {
                return ((int)(this["Lifetime_DefaultIterations"]));
            }
            set
            {
                this["Lifetime_DefaultIterations"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("250")]
        public double Lifetime_DefaultTemperature
        {
            get
            {
                return ((double)(this["Lifetime_DefaultTemperature"]));
            }
            set
            {
                this["Lifetime_DefaultTemperature"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int Production_DefaultIterations
        {
            get
            {
                return ((int)(this["Production_DefaultIterations"]));
            }
            set
            {
                this["Production_DefaultIterations"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Localhost")]
        public string Database_Server
        {
            get
            {
                return ((string)(this["Database_Server"]));
            }
            set
            {
                this["Database_Server"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("gci")]
        public string Database_Name
        {
            get
            {
                return ((string)(this["Database_Name"]));
            }
            set
            {
                this["Database_Name"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("root")]
        public string Database_Username
        {
            get
            {
                return ((string)(this["Database_Username"]));
            }
            set
            {
                this["Database_Username"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DieRemoval1")]
        public string Database_Password
        {
            get
            {
                return ((string)(this["Database_Password"]));
            }
            set
            {
                this["Database_Password"] = value;
            }
        }
    }
}
