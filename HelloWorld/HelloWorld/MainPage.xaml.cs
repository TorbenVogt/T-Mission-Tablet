﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

          Task task = new Task(ReadOurXML);
          task.Start();
           
        }

        private void inputButton_Click(object sender, RoutedEventArgs e)
        {
            greetingOutput.Text = "Hello mr. Scholar and gentleman " + nameInput.Text + "!" + " How are you?";
        }

        public static async void ReadOurXML()
        {
            XElement booksFromFile = XElement.Load(@"C:\AppData\dummy.xml");
  
        }
    }
}
