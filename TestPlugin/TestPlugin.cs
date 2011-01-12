﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Hell.CList;

namespace Hell
{
    /// <summary>
    /// Test managed Miranda plugin.
    /// </summary>
    // Every plugin main class must be marked with MirandaPlugin attribute and
    // be derived from abstract Hell.Plugin class.
    [MirandaPlugin]
    public class TestPlugin : Plugin
    {
        /// <summary>
        /// This object allows us to call Miranda API functions.
        /// </summary>
        private PluginLink pluginLink;

        /// <summary>
        /// ALWAYS remember to save delegates to your methods that can be
        /// called from Miranda. If you forget to do that, delegate will be
        /// garbage collected and method call will fail.
        /// </summary>
        private MirandaService menuCommand;

        /// <summary>
        /// Plugin object constructor.
        /// </summary>
        public TestPlugin(IntPtr hInstance)
            : base(hInstance)
        {
            menuCommand = PluginMenuCommand;
        }

        /// <summary>
        /// Load method will be called on plugin load.
        /// </summary>
        /// <param name="pluginLink">
        /// Provided PluginLink object contains pointers to Miranda service
        /// functions.
        /// </param>
        protected override void Load(PluginLink pluginLink)
        {
            this.pluginLink = pluginLink;

            pluginLink.CreateServiceFunction("TestPlug/MenuCommand",
                menuCommand);

            var mi = new CListMenuItem();
            mi.position = -0x7FFFFFFF;
            mi.flags = 0;
            // TODO: Load icon:
            // mi.hIcon = LoadSkinnedIcon(SKINICON_OTHER_MIRANDA);
            mi.name = "&Test Plugin...";
            mi.service = "TestPlug/MenuCommand";

            IntPtr pointer =
                Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CListMenuItem)));
            Marshal.StructureToPtr(mi, pointer, false);
            pluginLink.CallService("CList/AddMainMenuItem", IntPtr.Zero,
                pointer);
            Marshal.DestroyStructure(pointer, typeof(CListMenuItem));
        }

        /// <summary>
        /// Unload method will be called on plugin unloading (for example, on
        /// Miranda exit).
        /// </summary>
        public override void Unload()
        {
            
        }

        /// <summary>
        /// This method woll be called when user selects "Test Plugin..." menu
        /// item.
        /// </summary>
        private IntPtr PluginMenuCommand(IntPtr wParam, IntPtr lParam)
        {
            MessageBox.Show("Hello world from TestPlugin!");
            return IntPtr.Zero;
        }
    }
}