#pragma checksum "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fce003865c1492f91a7a346b8e14ac0a356c5c74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PetWalkSite.Pages.Pages_AppointmentAdmin), @"mvc.1.0.razor-page", @"/Pages/AppointmentAdmin.cshtml")]
namespace PetWalkSite.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\_ViewImports.cshtml"
using PetWalkSite;

#line default
#line hidden
#line 5 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
using System.Data;

#line default
#line hidden
#line 6 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
using System.Data.SqlClient;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fce003865c1492f91a7a346b8e14ac0a356c5c74", @"/Pages/AppointmentAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1b07940c0f58a43011cc2e4a1912a1704175964", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AppointmentAdmin : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("pets"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "BookAppointment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#line 8 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
  
    DataTable table = new DataTable();
    using (SqlConnection myConn = new SqlConnection(Program.da.cs))
    {
        string searchQuery = "SELECT * FROM pet";
        SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
        myConn.Open();
        table.Load(displayCommand.ExecuteReader());
        myConn.Close();
    } // using

#line default
#line hidden
            WriteLiteral("\r\n\r\n<h4>Appointment Portal</h4>\r\n");
#line 22 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
 if (@Model.alertMessage != null)
{

#line default
#line hidden
            WriteLiteral("    <script>alert(\"");
#line 24 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
              Write(Model.alertMessage);

#line default
#line hidden
            WriteLiteral("\");</script>\r\n");
#line 25 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
}

#line default
#line hidden
            WriteLiteral("<div class=\"formItem\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fce003865c1492f91a7a346b8e14ac0a356c5c745852", async() => {
                WriteLiteral(@"
        <div id=""hoursLeftSide"">
            <span class=""infoText"">Book for days:</span>
            <input required type=""date"" name=""day"" id=""weekdays2"">
        </div>
        <div id=""hoursRightSide"">
            <span class=""infoText"">select your pets</span>
            <select name=""pet"" required>
");
#line 35 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                 foreach (DataRow row in table.Rows)
                {

#line default
#line hidden
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fce003865c1492f91a7a346b8e14ac0a356c5c746688", async() => {
#line 37 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                                        Write(row["name"]);

#line default
#line hidden
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#line 37 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                   WriteLiteral(row["name"]);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#line 38 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                }

#line default
#line hidden
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fce003865c1492f91a7a346b8e14ac0a356c5c748778", async() => {
                    WriteLiteral("-- select --");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <br><br>\r\n        <div>\r\n");
#line 44 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
             if (@Model.names.Count > 0)
            {
                

#line default
#line hidden
#line 46 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                 for (int j = 0; j < @Model.nameGroup.Count; j++)
                {

#line default
#line hidden
                WriteLiteral("                    <p id=\"nameList\">");
#line 48 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                Write(Model.nameGroup[j]);

#line default
#line hidden
                WriteLiteral(": </p>\r\n                    <select name=\"timeTable\" id=\"timeTable\" required>\r\n");
#line 50 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                         for (int i = 0; i < @Model.names.Count; i++)
                        {
                            if (@Model.names[i] == @Model.nameGroup[j])
                            {

#line default
#line hidden
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fce003865c1492f91a7a346b8e14ac0a356c5c7412228", async() => {
#line 54 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                   Write(Model.startHours[i]);

#line default
#line hidden
                    WriteLiteral(" - ");
#line 54 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                                          Write(Model.endHours[i]);

#line default
#line hidden
                    WriteLiteral(" ");
#line 54 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                                                             Write(Model.days[i]);

#line default
#line hidden
                    WriteLiteral(" ");
#line 54 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                                                                                            Write(Model.nameGroup[j]);

#line default
#line hidden
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#line 55 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                            }
                        }

#line default
#line hidden
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fce003865c1492f91a7a346b8e14ac0a356c5c7414416", async() => {
                    WriteLiteral("-- select --");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </select>\r\n");
#line 59 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                }

#line default
#line hidden
#line 59 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                 
            }

#line default
#line hidden
                WriteLiteral("        </div>\r\n        <input type=\"submit\" value=\"Book Appointment\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
#line 66 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
  
    DataTable bookTable = new DataTable();
    using (SqlConnection myConn = new SqlConnection(Program.da.cs))
    {
        string searchQuery = "SELECT appointmentID, petID, DATENAME(weekday, dateBooked) AS dateBooked, " +
                    "appointmentDate, volunteerID, duration FROM appointment ORDER BY petID";
        SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
        myConn.Open();

        bookTable.Load(displayCommand.ExecuteReader());
        myConn.Close();
    } // using

    List<string> petNames = new List<string>();
    

#line default
#line hidden
#line 80 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
     foreach (DataRow row in bookTable.Rows)
    {
        

#line default
#line hidden
#line 82 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
         if ((int)@row["petID"] != 0)
        {
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT name FROM pet WHERE petID = " + @row["petID"];
                SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                SqlDataReader reader = displayCommand.ExecuteReader();
                reader.Read();
                petNames.Add((string)reader["name"]);
                myConn.Close();
            } // using
        }

#line default
#line hidden
#line 94 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
         
    }

#line default
#line hidden
#line 95 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
     
    List<string> volNames = new List<string>();
    

#line default
#line hidden
#line 97 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
     foreach (DataRow row in bookTable.Rows)
    {
        

#line default
#line hidden
#line 99 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
         if ((int)@row["volunteerID"] != 0)
        {
            using (SqlConnection myConn = new SqlConnection(Program.da.cs))
            {
                string searchQuery = "SELECT name FROM volunteer WHERE volunteerID = " + @row["volunteerID"];
                SqlCommand displayCommand = new SqlCommand(searchQuery, myConn);
                myConn.Open();
                SqlDataReader reader = displayCommand.ExecuteReader();
                reader.Read();
                volNames.Add((string)reader["name"]);
                myConn.Close();
            } // using
        }

#line default
#line hidden
#line 111 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
         
    }

#line default
#line hidden
            WriteLiteral(@"
<div class=""formItemTable"">
    <h5>Appointment Table</h5>
    <table border=""1"" class=""tableLayout"">
        <tr>
            <th>Availability ID</th>
            <th>Pet Name</th>
            <th>Date Booked</th>
            <th>Appointment Date</th>
            <th>Volunteer Name</th>
            <th>Duration(Hour)</th>
        </tr>
");
#line 126 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
          
            int h = 0;
            int s = 0;
            

#line default
#line hidden
#line 129 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
             foreach (DataRow row in bookTable.Rows)
            {

#line default
#line hidden
            WriteLiteral("                <tr>\r\n                    <td>");
#line 132 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(row["appointmentID"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td>");
#line 133 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(petNames[h++]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td>");
#line 134 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(row["dateBooked"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td>");
#line 135 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(row["appointmentDate"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td>");
#line 136 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(volNames[s++]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td>");
#line 137 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
                   Write(row["duration"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n");
#line 139 "D:\Web\SQL\Class Project\PetWalkSite\PetWalkSite\Pages\AppointmentAdmin.cshtml"
            }

#line default
#line hidden
            WriteLiteral("    </table>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PetWalkSite.Pages.AppointmentAdminModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PetWalkSite.Pages.AppointmentAdminModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<PetWalkSite.Pages.AppointmentAdminModel>)PageContext?.ViewData;
        public PetWalkSite.Pages.AppointmentAdminModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
