﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemoteDataAccessor.Engine.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RemoteDataAccessor.Engine.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not initialized.
        /// </summary>
        internal static string EngineValidateComponentNotInitilizedFatal {
            get {
                return ResourceManager.GetString("EngineValidateComponentNotInitilizedFatal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataAccessHelper {0} is reinitialization by dataAccessHelper {1} two dataAccessHelper in one system is a problem!.
        /// </summary>
        internal static string RegisterDataAccessHelperError {
            get {
                return ResourceManager.GetString("RegisterDataAccessHelperError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataAccessHelperSettings {0} is reinitialization by dataAccessHelperSettings {1} two dataAccessHelperSettings in one system is a problem!.
        /// </summary>
        internal static string RegisterDataAccessHelperSettingsError {
            get {
                return ResourceManager.GetString("RegisterDataAccessHelperSettingsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EngineSettings {0} is reinitialization by engineSettings {1} two engineSettings in one system is a problem!.
        /// </summary>
        internal static string RegisterEngineSettingsError {
            get {
                return ResourceManager.GetString("RegisterEngineSettingsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown component type.
        /// </summary>
        internal static string UnknownComponentFatal {
            get {
                return ResourceManager.GetString("UnknownComponentFatal", resourceCulture);
            }
        }
    }
}