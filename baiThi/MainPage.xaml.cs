using baiThi.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace baiThi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Student student = new Student();
        public MainPage()
        {
            this.InitializeComponent();
            LoadStudent();
        }
        private async void LoadStudent()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "lMyHzmDDg4vQik4XAmaOap9fy9VsDbH1HP6TMdJUCh3NHexd4rib2ASn05rCPpPG");
            var response = httpClient.GetAsync("https://localhost:44357/api/Students1");
            var content = await response.Result.Content.ReadAsStringAsync();
            Debug.WriteLine(content);
            student = JsonConvert.DeserializeObject<Student>(content);
            Debug.WriteLine(student.email);
            this.txt_name.Text = student.firstName + " " + student.lastName;
            this.txt_phone.Text = student.phoneNumber;
            this.txt_email.Text = student.email;
        }
    }
}
