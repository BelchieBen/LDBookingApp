﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LDBookingApp.Utility {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LDBookingApp.Utility.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Are you sure you want to delete: {0}.
        /// </summary>
        internal static string Delete_Message {
            get {
                return ResourceManager.GetString("Delete_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have no internet connection, please restore connection and continue.
        /// </summary>
        internal static string No_Connection {
            get {
                return ResourceManager.GetString("No_Connection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ok.
        /// </summary>
        internal static string Ok {
            get {
                return ResourceManager.GetString("Ok", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Refreh Error.
        /// </summary>
        internal static string Refresh_error {
            get {
                return ResourceManager.GetString("Refresh_error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Signup Failed.
        /// </summary>
        internal static string Signup_Failed {
            get {
                return ResourceManager.GetString("Signup_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something went wrong, Please try again!.
        /// </summary>
        internal static string Something_Went_Wrong {
            get {
                return ResourceManager.GetString("Something_Went_Wrong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Try Again.
        /// </summary>
        internal static string Try_Again {
            get {
                return ResourceManager.GetString("Try_Again", resourceCulture);
            }
        }
    }
}
