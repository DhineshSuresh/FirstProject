using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.Text;
using System.Web;
using iTextSharp.text.html;
using iTextSharp.tool.xml.pipeline;
using iText;
using iText.Pdfa;
using System.Data;
using ASPSnippets.LinkedInAPI;
using System.Net;

namespace PDF.Controllers
{
    public class HomeController : Controller
    {
        //private string sr;

        public object XMLWorkerHelper { get; private set; }
        public object Tags { get; private set; }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GenerateXml()
        {
            return View();
        }
        public ActionResult LinkedIN_Login()
        {
            if (LinkedInConnect.IsAuthorized)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                DataSet ds = LinkedInConnect.Fetch();
                //ViewBag.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
                ViewBag.firstname = ds.Tables["person"].Rows[0]["first-name"].ToString();
                ViewBag.lastname += " " + ds.Tables["person"].Rows[0]["last-name"].ToString();
                ViewBag.email = ds.Tables["person"].Rows[0]["email-address"].ToString();
                //lblHeadline.Text = ds.Tables["person"].Rows[0]["headline"].ToString();
                //lblIndustry.Text = ds.Tables["person"].Rows[0]["industry"].ToString();
                //lblLinkedInId.Text = ds.Tables["person"].Rows[0]["id"].ToString();
                //lblLocation.Text = ds.Tables["location"].Rows[0]["name"].ToString();
                //imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
               
            }
            return View();
        }
    
        public void Authorize()
        {
            LinkedInConnect.APIKey = "81n6w847yiux54";
            LinkedInConnect.APISecret = "tg2XnPGyI7oYx7xS";
            LinkedInConnect.RedirectUrl = "http://localhost:52148/Home/LinkedIN_Login";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            LinkedInConnect.Authorize();

            
           
        }
        public ActionResult PdfGeneration()
        {
            return View();
        }
        public ActionResult ItextPdfGen()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("<!DOCTYPE html><html lang='en'><head><title>Lowenstein</title><meta charset='utf-8' /><meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' /> <style> html, body { margin: 0px; } table, td, th { padding: 0px; margin: 0px; line-height: 0px; } body { font-family: 'Roboto Condensed', sans-serif; font-size: 30px; color: #231f20; background-color: #fff; line-height: 0px; max-width: 595px; margin: 0px auto; padding-top: 50px; } table { width: 100%; align: center; margin: 0px; } a { color: #231f20; text-decoration: none; font-weight: 700; } a.fw-500 { font-weight: 400; } table.content * { align: left; } table.header, table.titlebar { margin-bottom: 15px; } table.banner { width: 100%; } table.date, table.banner, table.titlesection, table.titlesection { margin-bottom: 10px; } table.titlebar { background-color: #575757; } table.titlebg{ background-color:#efeded; } table.titlebar h1 { margin: 0px; color: #fff; font-size: 25.62px; font-weight: 700; line-height: 25.62px; } table.titlebar h3 { margin: 0px; color: #fff; } table.titlebar h4 { margin: 0px; color: #fff; } table.header p { color: #575757; font-size: 24.02px; line-height: 11.31px; position:fixed; } table.date p { color: #a2a4a7; font-size: 15.37px; line-height: 17.96px; } table.titlesection h2 { color: #000000; font-weight: 700; font-size: 22.79px; font-size: 22.46px; } table.titlesection p { color: #000000; font-size: 13.35px; font-size: 13.35px; } table.titlesection a { color: #ec2028; } table.banner img { width: 100%; } p, strong { margin: 0px; font-size: 10.24px; line-height: 15.36px; } strong { font-weight: 700; } p { font-weight: 400; width: 100%; } h2 { margin: 0px; font-size: 19.19px; line-height: 18.91px; font-weight: 700; text-transform: uppercase; } h3 { margin: 0px; font-size: 12.82px; font-weight: 700; line-height: 14.51px; } ul li { font-size: 10.67px; line-height: 16px; margin-left: 20px; } ul { margin-top: 10px; } .contentarea { column-count: 3; } * { box-sizing: border-box;} div.divHeader { position: fixed; height:100px; top:0; margin-bottom: -20px; width:100%; position:fixed; left:0 }/* Create two equal columns that floats next to each other */.column { float: left; width: 50%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}.columnlist { float: left; width: 10%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}/* Clear floats after the columns */.row:after { content: ''; display: table; clear: both;}ul.b {list-style-type: disc;color:red}/*#thead { display: table-header-group; }tfoot { display: table-row-group; }tr { page-break-inside: avoid; }*/ </style></head><body><table border='0' cellpadding='0' cellspacing='0' class='titlebar'> <tr> <td align='left'><br /><h1 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>Bankruptcy, Financial Reorganization & Creditors' Rights Investment Management</h1></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='date'> <tr> <td align='left'><p>March 7, 2018</p></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='banner'> <tr> <td> <img src='http://lowen.activitystaging.com:81/pdfTemplate/img/banner.jpg' alt='banner' style='width:720px;' /> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='titlesection'> <tr> <td width='1%' style='background-color:#ec2028;'> <p>&nbsp;</p> </td> <td width='1%'> <p>&nbsp;</p> </td> <td width='98%'> <h2> Lessons From Merit Management: The Settlement Payment Defense Lives … if You Are a “Financial Institution” </h2> <p>By <a href='#'>Jeffrey Cohen</a>, <a href='#'>Richard Bernstein</a>, <a href='#'>Michael A. Brosse</a>, <a href='#'>Paul Kizel</a>, <a href='#'>Benjamin Kozinn</a>, <a href='#'>Jonathan C. Wishnia</a>, and <a href='#'>Gabriel L. Olivera</a></p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>What You Need To Know:</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> In Merit Management, the Supreme Court squarely addresses and resolves the circuit court split on whether the “settlement payment” defense can be implemented to insulate subsequent transferees in a constructive fraud case. </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> By agreeing with the Seventh Circuit, courts are now instructed to look at the entire transaction as a whole and focus on the ultimate transferee, rather than the existence of an intervening “financial institution.” </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> The “settlement payment” defense, however, remains a viable defense if the involved party is considered a “financial institution,” the definition of which the Supreme Court elected not to address in the Merit decision. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> In a much-awaited decision, the Supreme Court finally resolved the longstanding split among the circuit courts regarding the applicability of the “settlement payment defense” under 546(e) of the Bankruptcy Code (the Settlement Payment Defense). The Merit Management1 Court’s focus on § 546(e)’s scope should ease the minds of those who worried the Supreme Court would limit the Bankruptcy Code’s definition of a “financial institution. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p><h3> 1. THE SETTLEMENT PAYMENT DEFENSE</h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> The Settlement Payment Defense shields covered entities from constructive fraudulent conveyance actions by precluding a trustee from recovering a “settlement payment” or “transfer” made “by or to (or for the benefit of)” these entities, including financial institutions. Many defendant-transferees raise the Settlement Payment Defense to protect their received settlement payment </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> Prior to the Merit Management decision, circuit courts had two views on the reach of the Settlement Payment Defense. One view (the Plurality View), subscribed to by five circuitcourts, allowed the existence of a financial institution in the chain of transfers to insulate subsequent transferees from liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' class='banner'> <tr> <td> <img src='http://lowen.activitystaging.com:81/pdfTemplate/img/banner.jpg' alt='banner' style='width:720px;' /> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> Et magnis dis parturient montes, nascetur ridiculus The Seventh Circuit proposed a different view (the Seventh Circuit View), which looked at the transaction as a whole and focused on the ultimate transferee. Namely, the Seventh Circuit held that the Settlement Payment Defense did not apply when the only covered entity is the financial institution that served as a mere conduit for the distribution of payment to the transferee. In Merit Management, one side argued in favor of the Plurality View, and the other asserted that the Seventh Circuit View applies. mus. Donec quam felis, ultricies nec, pellentesque eu, </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 3. BRIEF FACTS IN MERIT MANAGEMENT </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> The Merit Management case involved a chapter 11 trustee (the Trustee) that identified what it considered to be a constructive fraudulent transfer from the Debtor to a transferee (the Transferee). The Trustee alleged that the Debtor purchased stock from the Transferee at a price that did not provide fair value.3 Therefore, the Trustee filed suit to recover (“avoid”) the allegedly dubious pre-petition payments. The Transferee filed a motion on the pleadings, whereby it argued that the Settlement Payment Defense barred the Trustee from recovery pursuant to the Plurality View. Specifically, the Transferee argued that the Settlement Payment Defense insulated the relevant transaction from scrutiny, because the final payment to the Transferee was not made by the Debtor, but rather “by” a protected intermediary: a financial institution that served as a conduit for the transfer of payment. The Trustee countered with the Seventh Circuit View: the Settlement Payment Defense cannot be used to insulate transfers that were made through a financial institution but did not involve said financial institution as a direct party. The Supreme Court agreed with the Trustee, but on broader grounds. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 4. THE MERIT MANAGEMENT HOLDING </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> The Merit Management Court did not did limit the definition of a “financial institution” in any way. Instead, it simply held that when considering the Settlement Payment Defense, courts are to concentrate on the overarching transaction from initial transferor to end transferee, and not on the component parts. Focusing its discussion on this general holding, the Merit Management Court clarified that using a financial institution as a mere conduit for the distribution of funds does not shield a transaction from avoidance actions. Essentially, courts should “look to the transfer that the trustee seeks to avoid (i.e., A → D) to determine whether” the Settlement Payment Defense insulates said transfer, and should not look to the “component parts of the overarching transfer (i.e., A → B → C → D).”4 The Supreme Court did not discuss whether the Debtor or the Transferee qualified as a “financial institution.” Thus, despite Merit Management’s holding, defendants can still avail themselves of the Settlement Payment Defense if they claim “financial institution” status as part of their defense. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 5. POST-MERIT MANAGEMENT IMPLICATIONS </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> While the decision will deprive some avoidance defendants of the ability to use the Settlement Payment Defense, said defense still applies when the financial institution asserting the Settlement Payment Defense is the conduit-bank’s “customer.” The Merit Management ruling did not limit the Bankruptcy Code’s definition of a “financial institution.” As previously stated, the Settlement Payment Defense precludes a trustee from avoiding a “settlement payment” or “transfer” made “by or to (or for the benefit of)” The Bankruptcy Code’s definition of “financial institutions” includes the “customer” of certain banks or commercial entities when a bank or commercial entity acts as an agent or custodian for the customer in connection with a securities contract.5 Hypothetically speaking, a transferee that is also a customer of a bank or commercial entity serving as an intermediary to a transaction could use the Settlement Payment Defense to insulate itself from an avoidance action, given that the Bankruptcy Code also defines said customer as a protected “financial institution.” At the Merit Management oral argument, Justice Stephen Breyer suggested that this might be a valid justification for transferees to continue using the Settlement Payment Defense.6 However, the Court chose to not discuss the Bankruptcy Code’s definition of a “financial institution,” as the Transferee conceded the aforementioned point in the lower courts. Thus, it still remains true that a financial institution may avail itself of the Settlement Payment Defense if it is one of the transacting parties, as opposed to an intermediary. Given this development, the main takeaway for securities market participants is that they must demand a detailed transfer structure that gives them “financial institution” status in order to curtail avoidance liability. Many circuit courts are mindful of the importance of financial market stability and certainty, and the detrimental effects that would result from subjecting all securities transactions to avoidance actions. By insisting on a transfer structure whereby transferees fit within the Bankruptcy Code’s definition of a “financial institution,” market participants will safeguard their securities transactions from avoidance risk. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 6. CONCLUSION </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='55'> <p> Focusing its attention on Merit Management’s specific facts, the Supreme Court’s ruling appears to leave in place protections for certain shareholders receiving settlement payments under securities contracts. Going forward, market participants that seek certainty and finality in their transactions will be wise to ensure that they qualify for “financial institution” status prior to entering into a securities transaction. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>Related Areas</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='35'> <p> Bankruptcy, Financial Reorganization & Creditors' Rights </p> </td> </tr> <tr> <td width='100%' valign='top' height='35'> <p> Investment Management </p> </td> </tr> <tr> <td width='100%' valign='top' height='35'> <p> Private Equity </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>You may also be interested in</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> The SEC's 2018 Examination Priorities </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> Year-End Developments and Compliance Checklists </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> Key Tax Provisions Affecting Hedge Funds, Private Equity Funds And Other Investment Vehicles </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> Contacts </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='5' class='titlebar'> <tr> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>YEO YORK</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>PALO ALTO</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>YEW JERSEY</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>UTAH</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>WASHINTON,D.C</h3></td> </tr> <tr> <td align='center' colspan='5'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>(C) 2018-2019 Lowenstein Sandler LLP</h3></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='55'> <p> This Alert has been prepared by Lowenstein Sandler LLP to provide information on recent legal developments of interest to our readers. It is not intended to provide legal advice for specific situation or to create an attorney-client relationship.Lowenstein Sandler assumes to responsibility to update the Alert based upon events subsequent to the date of its publication,such as new legislation,regulations and judicial decisions.You should consult with counsel to determine applicable legal requirements in a specific fact situation </p> </td> </tr> </table> </body></html>");
            //sb.Append("<!DOCTYPE html><html lang='en'><head><title>Lowenstein</title><meta charset='utf-8' /><meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' /> <style> html, body { margin: 0px; } table, td, th { padding: 0px; margin: 0px; line-height: 0px; } body { font-family: 'Roboto Condensed', sans-serif; font-size: 30px; color: #231f20; background-color: #fff; line-height: 0px; max-width: 595px; margin: 0px auto; padding-top: 50px; } table { width: 100%; align: center; margin: 0px; } a { color: #231f20; text-decoration: none; font-weight: 700; } a.fw-500 { font-weight: 400; } table.content * { align: left; } table.header, table.titlebar { margin-bottom: 15px; } table.banner { width: 100%; } table.date, table.banner, table.titlesection, table.titlesection { margin-bottom: 10px; } table.titlebar { background-color: #575757; } table.titlebg{ background-color:#efeded; } table.titlebar h1 { margin: 0px; color: #fff; font-size: 25.62px; font-weight: 700; line-height: 25.62px; } table.titlebar h3 { margin: 0px; color: #fff; } table.titlebar h4 { margin: 0px; color: #fff; } table.header p { color: #575757; font-size: 24.02px; line-height: 11.31px; position:fixed; } table.date p { color: #a2a4a7; font-size: 15.37px; line-height: 17.96px; } table.titlesection h2 { color: #000000; font-weight: 700; font-size: 22.79px; font-size: 22.46px; } table.titlesection p { color: #000000; font-size: 13.35px; font-size: 13.35px; } table.titlesection a { color: #ec2028; } table.banner img { width: 100%; } p, strong { margin: 0px; font-size: 10.24px; line-height: 15.36px; } strong { font-weight: 700; } p { font-weight: 400; width: 100%; } h2 { margin: 0px; font-size: 19.19px; line-height: 18.91px; font-weight: 700; text-transform: uppercase; } h3 { margin: 0px; font-size: 12.82px; font-weight: 700; line-height: 14.51px; } ul li { font-size: 10.67px; line-height: 16px; margin-left: 20px; } ul { margin-top: 10px; } .contentarea { column-count: 3; } * { box-sizing: border-box;} div.divHeader { position: fixed; height:100px; top:0; margin-bottom: -20px; width:100%; position:fixed; left:0 }/* Create two equal columns that floats next to each other */.column { float: left; width: 50%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}.columnlist { float: left; width: 10%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}/* Clear floats after the columns */.row:after { content: ''; display: table; clear: both;}ul.b {list-style-type: disc;color:red}/*#thead { display: table-header-group; }tfoot { display: table-row-group; }tr { page-break-inside: avoid; }*/ </style></head><body> <table border='0' cellpadding='0' cellspacing='0' class='titlebar'> <tr> <td align='left'><br /><h1 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>Bankruptcy, Financial Reorganization & Creditors' Rights Investment Management</h1></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='date'> <tr> <td align='left'><p>March 7, 2018</p></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='banner'> <tr> <td> <img src='http://lowen.activitystaging.com:81/pdfTemplate/img/banner.jpg' alt='banner' style='width:720px;' /> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='0' class='titlesection'> <tr> <td width='1%' style='background-color:#ec2028;'> <p>&nbsp;</p> </td> <td width='1%'> <p>&nbsp;</p> </td> <td width='98%'> <h2> Lessons From Merit Management: The Settlement Payment Defense Lives … if You Are a “Financial Institution” </h2> <p>By <a href='#'>Jeffrey Cohen</a>, <a href='#'>Richard Bernstein</a>, <a href='#'>Michael A. Brosse</a>, <a href='#'>Paul Kizel</a>, <a href='#'>Benjamin Kozinn</a>, <a href='#'>Jonathan C. Wishnia</a>, and <a href='#'>Gabriel L. Olivera</a></p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>What You Need To Know:</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> In Merit Management, the Supreme Court squarely addresses and resolves the circuit court split on whether the “settlement payment” defense can be implemented to insulate subsequent transferees in a constructive fraud case. </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> By agreeing with the Seventh Circuit, courts are now instructed to look at the entire transaction as a whole and focus on the ultimate transferee, rather than the existence of an intervening “financial institution.” </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> The “settlement payment” defense, however, remains a viable defense if the involved party is considered a “financial institution,” the definition of which the Supreme Court elected not to address in the Merit decision. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> In a much-awaited decision, the Supreme Court finally resolved the longstanding split among the circuit courts regarding the applicability of the “settlement payment defense” under 546(e) of the Bankruptcy Code (the Settlement Payment Defense). The Merit Management1 Court’s focus on § 546(e)’s scope should ease the minds of those who worried the Supreme Court would limit the Bankruptcy Code’s definition of a “financial institution. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p><h3> 1. THE SETTLEMENT PAYMENT DEFENSE</h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> The Settlement Payment Defense shields covered entities from constructive fraudulent conveyance actions by precluding a trustee from recovering a “settlement payment” or “transfer” made “by or to (or for the benefit of)” these entities, including financial institutions. Many defendant-transferees raise the Settlement Payment Defense to protect their received settlement payment </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> Prior to the Merit Management decision, circuit courts had two views on the reach of the Settlement Payment Defense. One view (the Plurality View), subscribed to by five circuitcourts, allowed the existence of a financial institution in the chain of transfers to insulate subsequent transferees from liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' class='banner'> <tr> <td> <img src='http://lowen.activitystaging.com:81/pdfTemplate/img/banner.jpg' alt='banner' style='width:720px;' /> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> Et magnis dis parturient montes, nascetur ridiculus The Seventh Circuit proposed a different view (the Seventh Circuit View), which looked at the transaction as a whole and focused on the ultimate transferee. Namely, the Seventh Circuit held that the Settlement Payment Defense did not apply when the only covered entity is the financial institution that served as a mere conduit for the distribution of payment to the transferee. In Merit Management, one side argued in favor of the Plurality View, and the other asserted that the Seventh Circuit View applies. mus. Donec quam felis, ultricies nec, pellentesque eu, </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 3. BRIEF FACTS IN MERIT MANAGEMENT </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> The Merit Management case involved a chapter 11 trustee (the Trustee) that identified what it considered to be a constructive fraudulent transfer from the Debtor to a transferee (the Transferee). The Trustee alleged that the Debtor purchased stock from the Transferee at a price that did not provide fair value.3 Therefore, the Trustee filed suit to recover (“avoid”) the allegedly dubious pre-petition payments. The Transferee filed a motion on the pleadings, whereby it argued that the Settlement Payment Defense barred the Trustee from recovery pursuant to the Plurality View. Specifically, the Transferee argued that the Settlement Payment Defense insulated the relevant transaction from scrutiny, because the final payment to the Transferee was not made by the Debtor, but rather “by” a protected intermediary: a financial institution that served as a conduit for the transfer of payment. The Trustee countered with the Seventh Circuit View: the Settlement Payment Defense cannot be used to insulate transfers that were made through a financial institution but did not involve said financial institution as a direct party. The Supreme Court agreed with the Trustee, but on broader grounds. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 4. THE MERIT MANAGEMENT HOLDING </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> The Merit Management Court did not did limit the definition of a “financial institution” in any way. Instead, it simply held that when considering the Settlement Payment Defense, courts are to concentrate on the overarching transaction from initial transferor to end transferee, and not on the component parts. Focusing its discussion on this general holding, the Merit Management Court clarified that using a financial institution as a mere conduit for the distribution of funds does not shield a transaction from avoidance actions. Essentially, courts should “look to the transfer that the trustee seeks to avoid (i.e., A → D) to determine whether” the Settlement Payment Defense insulates said transfer, and should not look to the “component parts of the overarching transfer (i.e., A → B → C → D).”4 The Supreme Court did not discuss whether the Debtor or the Transferee qualified as a “financial institution.” Thus, despite Merit Management’s holding, defendants can still avail themselves of the Settlement Payment Defense if they claim “financial institution” status as part of their defense. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 5. POST-MERIT MANAGEMENT IMPLICATIONS </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='25'> <p> While the decision will deprive some avoidance defendants of the ability to use the Settlement Payment Defense, said defense still applies when the financial institution asserting the Settlement Payment Defense is the conduit-bank’s “customer.” The Merit Management ruling did not limit the Bankruptcy Code’s definition of a “financial institution.” As previously stated, the Settlement Payment Defense precludes a trustee from avoiding a “settlement payment” or “transfer” made “by or to (or for the benefit of)” The Bankruptcy Code’s definition of “financial institutions” includes the “customer” of certain banks or commercial entities when a bank or commercial entity acts as an agent or custodian for the customer in connection with a securities contract.5 Hypothetically speaking, a transferee that is also a customer of a bank or commercial entity serving as an intermediary to a transaction could use the Settlement Payment Defense to insulate itself from an avoidance action, given that the Bankruptcy Code also defines said customer as a protected “financial institution.” At the Merit Management oral argument, Justice Stephen Breyer suggested that this might be a valid justification for transferees to continue using the Settlement Payment Defense.6 However, the Court chose to not discuss the Bankruptcy Code’s definition of a “financial institution,” as the Transferee conceded the aforementioned point in the lower courts. Thus, it still remains true that a financial institution may avail itself of the Settlement Payment Defense if it is one of the transacting parties, as opposed to an intermediary. Given this development, the main takeaway for securities market participants is that they must demand a detailed transfer structure that gives them “financial institution” status in order to curtail avoidance liability. Many circuit courts are mindful of the importance of financial market stability and certainty, and the detrimental effects that would result from subjecting all securities transactions to avoidance actions. By insisting on a transfer structure whereby transferees fit within the Bankruptcy Code’s definition of a “financial institution,” market participants will safeguard their securities transactions from avoidance risk. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> 6. CONCLUSION </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='55'> <p> Focusing its attention on Merit Management’s specific facts, the Supreme Court’s ruling appears to leave in place protections for certain shareholders receiving settlement payments under securities contracts. Going forward, market participants that seek certainty and finality in their transactions will be wise to ensure that they qualify for “financial institution” status prior to entering into a securities transaction. </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>Related Areas</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='35'> <p> Bankruptcy, Financial Reorganization & Creditors' Rights </p> </td> </tr> <tr> <td width='100%' valign='top' height='35'> <p> Investment Management </p> </td> </tr> <tr> <td width='100%' valign='top' height='35'> <p> Private Equity </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='100%' valign='top' height='25'> <p> <strong>You may also be interested in</strong> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%' class='titlebg'> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> The SEC's 2018 Examination Priorities </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> Year-End Developments and Compliance Checklists </p> </td> </tr> <tr> <td width='3%' valign='top' style='color: red; font-size: 22px;'> <strong style='line-height:2px; font-size: 22px;'>.</strong> </td> <td width='97%' valign='top' height='35'> <p> Key Tax Provisions Affecting Hedge Funds, Private Equity Funds And Other Investment Vehicles </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td width='100%' valign='top' height='25'> <p> <h3> Contacts </h3> </p> </td> </tr> </table> <table border='0' cellpadding='0' cellspacing='5' class='titlebar'> <tr> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>YEO YORK</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>PALO ALTO</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>YEW JERSEY</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>UTAH</h3></td> <td align='left'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>WASHINTON,D.C</h3></td> </tr> <tr> <td align='center' colspan='5'><br /><h3 style='padding-left:20px;padding-right:20px;padding-bottom:10px;'>(C) 2018-2019 Lowenstein Sandler LLP</h3></td> </tr> </table> <table border='0' cellpadding='0' cellspacing='10' width='100%'> <tr> <td height='55'> <p> This Alert has been prepared by Lowenstein Sandler LLP to provide information on recent legal developments of interest to our readers. It is not intended to provide legal advice for specific situation or to create an attorney-client relationship.Lowenstein Sandler assumes to responsibility to update the Alert based upon events subsequent to the date of its publication,such as new legislation,regulations and judicial decisions.You should consult with counsel to determine applicable legal requirements in a specific fact situation </p> </td> </tr> </table> </body></html>");

            StringReader sr = new StringReader(sb.ToString());

            Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 70f, 30f); 

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("E:\\PDF\\NewPdf3.pdf", FileMode.Create));
            pdfDoc.Open();
            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);



           
            pdfDoc.Close();


            //string file1 = "C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf2.pdf";


           
            //addpagenumber(file1);





            return View();
        }

        public class HtmlPageEventHelper : PdfPageEventHelper
        {
            public HtmlPageEventHelper(string html)
            {
                this.html = html;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                ColumnText ct = new ColumnText(writer.DirectContent);
                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(html));
                List<IElement> htmlarraylist = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(html, null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {

                    ct.AddElement((IElement)htmlarraylist[k]);


                }
                ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-20), 10, Element.ALIGN_MIDDLE);
                ct.Go();
            }

            string html = null;
        }
        //public class ColumnTextElementHandler : IElementHandler
        //{
        //    public ColumnTextElementHandler(ColumnText ct)
        //    {
        //        this.ct = ct;
        //    }

        //    ColumnText ct = null;

        //    public void Add(IWritable w)
        //    {
        //        if (w is WritableElement)
        //        {
        //            foreach (IElement e in ((WritableElement)w).Elements())
        //            {
        //                ct.AddElement(e);
        //            }
        //        }
        //    }
        //}
        public void addpagenumber(string file1)
        {

            //      String htmlText = "<font  " +
            //" color=\"#0000FF\"><b><i>Title One</i></b></font><font   " +
            //" color=\"black\"><br><br>Some text here<br><br><br><font   " +
            //" color=\"#0000FF\"><b><i>Another title here   " +
            //" </i></b></font><font   " +
            //" color=\"black\"><br><br>Text1<br>Text2<br><OL><LI>hi</LI><LI>how are u</LI></OL>";


            string htmlText = "<!DOCTYPE html><html lang='en'><head> <title>Lowenstein</title> <meta charset='utf-8' /> <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' /> <style> html, body { margin: 0px; } table, td, th { padding: 0px; margin: 0px; line-height: 0px; } body { font-family: 'Roboto Condensed', sans-serif; font-size: 30px; color: #231f20; background-color: #fff; line-height: 0px; max-width: 595px; margin: 0px auto; padding-top: 50px; } table { width: 100%; align: center; margin: 0px; } a { color: #231f20; text-decoration: none; font-weight: 700; } a.fw-500 { font-weight: 400; } table.content * { align: left; } table.header, table.titlebar { margin-bottom: 15px; } table.banner { width: 100%; } table.date, table.banner, table.titlesection, table.titlesection { margin-bottom: 10px; } table.titlebar { background-color: #575757; } table.titlebg{ background-color:#efeded; } table.titlebar h1 { margin: 0px; color: #fff; font-size: 25.62px; font-weight: 700; line-height: 25.62px; } table.titlebar h3 { margin: 0px; color: #fff; } table.titlebar h4 { margin: 0px; color: #fff; } table.header p { color: #575757; font-size: 24.02px; line-height: 11.31px; position:fixed; } table.date p { color: #a2a4a7; font-size: 15.37px; line-height: 17.96px; } table.titlesection h2 { color: #000000; font-weight: 700; font-size: 22.79px; font-size: 22.46px; } table.titlesection p { color: #000000; font-size: 13.35px; font-size: 13.35px; } table.titlesection a { color: #ec2028; } table.banner img { width: 100%; } p, strong { margin: 0px; font-size: 10.24px; line-height: 15.36px; } strong { font-weight: 700; } p { font-weight: 400; width: 100%; } h2 { margin: 0px; font-size: 19.19px; line-height: 18.91px; font-weight: 700; text-transform: uppercase; } h3 { margin: 0px; font-size: 12.82px; font-weight: 700; line-height: 14.51px; } ul li { font-size: 10.67px; line-height: 16px; margin-left: 20px; } ul { margin-top: 10px; } .contentarea { column-count: 3; } * { box-sizing: border-box;} div.divHeader { position: fixed; height:100px; top:0; margin-bottom: -20px; width:100%; position:fixed; left:0 }/* Create two equal columns that floats next to each other */.column { float: left; width: 50%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}.columnlist { float: left; width: 10%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}/* Clear floats after the columns */.row:after { content: ''; display: table; clear: both;}ul.b {list-style-type: disc;color:red}/*#thead { display: table-header-group; }tfoot { display: table-row-group; }tr { page-break-inside: avoid; }*/ </style></head><body> <table border='0' cellpadding='0' cellspacing='0' class='header'> <tr> <td align='left'> <img style='width:147px;' src='http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png' /> </td> <td align='right'> <p>Client Alert</p> </td> </tr> </table></body></html>";

            string htmlText2 = "<!DOCTYPE html><html lang='en'><head> <title>Lowenstein</title> <meta charset='utf-8' /> <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' /> <style> html, body { margin: 0px; } table, td, th { padding: 0px; margin: 0px; line-height: 0px; } body { font-family: 'Roboto Condensed', sans-serif; font-size: 30px; color: #231f20; background-color: #fff; line-height: 0px; max-width: 595px; margin: 0px auto; padding-top: 50px; } table { width: 100%; align: center; margin: 0px; } a { color: #231f20; text-decoration: none; font-weight: 700; } a.fw-500 { font-weight: 400; } table.content * { align: left; } table.header, table.titlebar { margin-bottom: 15px; } table.banner { width: 100%; } table.date, table.banner, table.titlesection, table.titlesection { margin-bottom: 10px; } table.titlebar { background-color: #575757; } table.titlebg{ background-color:#efeded; } table.titlebar h1 { margin: 0px; color: #fff; font-size: 25.62px; font-weight: 700; line-height: 25.62px; } table.titlebar h3 { margin: 0px; color: #fff; } table.titlebar h4 { margin: 0px; color: #fff; } table.header p { color: #575757; font-size: 24.02px; line-height: 11.31px; position:fixed; } table.date p { color: #a2a4a7; font-size: 15.37px; line-height: 17.96px; } table.titlesection h2 { color: #000000; font-weight: 700; font-size: 22.79px; font-size: 22.46px; } table.titlesection p { color: #000000; font-size: 13.35px; font-size: 13.35px; } table.titlesection a { color: #ec2028; } table.banner img { width: 100%; } p, strong { margin: 0px; font-size: 10.24px; line-height: 15.36px; } strong { font-weight: 700; } p { font-weight: 400; width: 100%; } h2 { margin: 0px; font-size: 19.19px; line-height: 18.91px; font-weight: 700; text-transform: uppercase; } h3 { margin: 0px; font-size: 12.82px; font-weight: 700; line-height: 14.51px; } ul li { font-size: 10.67px; line-height: 16px; margin-left: 20px; } ul { margin-top: 10px; } .contentarea { column-count: 3; } * { box-sizing: border-box;} div.divHeader { position: fixed; height:100px; top:0; margin-bottom: -20px; width:100%; position:fixed; left:0 }/* Create two equal columns that floats next to each other */.column { float: left; width: 50%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}.columnlist { float: left; width: 10%; padding: 10px; height: 300px; /* Should be removed. Only for demonstration */}/* Clear floats after the columns */.row:after { content: ''; display: table; clear: both;}ul.b {list-style-type: disc;color:red}/*#thead { display: table-header-group; }tfoot { display: table-row-group; }tr { page-break-inside: avoid; }*/ </style></head><body> <table border='0' cellpadding='0' cellspacing='0' class='header'> <tr> <td align='left'> <img style='width:147px;' src='http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png' /> </td> <td align='right'></td> </tr> </table><div width='100%' height='0.5px' style='background-color:black'></div></body></html>";

            //string htmlText = "<style>p{font-size:10px;color:#0000FF;}</style><img style='width:147px;' src='http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png' /><p>Client Alert</p>";
            // string htmlText = "<table border='0' cellpadding='0' cellspacing='0' class='header'> <tr> <td align='left'> <img style='width:147px;' src='http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png' /> </td> <td align='right'> <p>Client Alert</p> </td> </tr> </table>";
            //List<IElement> htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmlText), null);

            PdfReader reader = new PdfReader(file1);
            int n = reader.NumberOfPages;
            //Rectangle psize = reader.GetPageSize(1);
            Document document = new Document(PageSize.A4, 30f, 30f, 20f, 30f);
            //HTMLWorker htmlparser = new HTMLWorker(document);
            //StringReader sr = new StringReader(htmlText.ToString());
            PdfWriter writer1 = PdfWriter.GetInstance(document, new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf7.pdf", FileMode.Create));
            //writer1.PageEvent = new HtmlPageEventHelper(htmlText);
            document.Open();




            PdfContentByte cb = writer1.DirectContent;

            //iTextSharp.text.pdf.PdfCopy.PageStamp stamper = null;

            int p = 0;
            Console.WriteLine("There are " + n + " pages in the document.");

            Image L = Image.GetInstance("http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png");

            //L.SetAbsolutePosition(document.Left, document.Top - 180);

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                document.NewPage();

                if (page >  1)
                {
              
                    try
                    {
                        document.SetMargins(30f, 30f, 20f, 30f);
                        ColumnText ct = new ColumnText(writer1.DirectContent);
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, new StringReader(htmlText2));
                        List<IElement> htmlarraylist = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(htmlText2, null);
                        for (int k = 0; k < htmlarraylist.Count; k++)
                        {
                            StreamReader sr = new StreamReader(htmlarraylist[k].ToString());
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, sr);

                            ct.AddElement((IElement)htmlarraylist[k]);


                        }
                        ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-20), 10, Element.ALIGN_MIDDLE);
                        ct.Go();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    try
                    {
                        document.SetMargins(30f, 30f, 20f, 30f);

                        ColumnText ct1 = new ColumnText(writer1.DirectContent);
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, new StringReader(htmlText));
                        List<IElement> htmlarraylist1 = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(htmlText, null);
                        for (int k = 0; k < htmlarraylist1.Count; k++)
                        {
                            StreamReader sr1 = new StreamReader(htmlarraylist1[k].ToString());
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, sr1);

                            ct1.AddElement((IElement)htmlarraylist1[k]);


                        }
                        ct1.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-5000), 10, Element.ALIGN_MIDDLE);
                        ct1.Go();


                       
                        





                    }
                    catch (Exception ex)
                    {

                    }
                }
                // writer1.PageEvent = new HtmlPageEventHelper(htmlText);



                //try
                //{

                //    document.SetMargins(30f, 30f, 20f, 600f);

                //    ColumnText ct2 = new ColumnText(writer1.DirectContent);
                //    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, new StringReader(htmlText));
                //    List<IElement> htmlarraylist2 = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(htmlText, null);
                //    for (int k = 0; k < htmlarraylist2.Count; k++)
                //    {
                //        StreamReader sr2 = new StreamReader(htmlarraylist2[k].ToString());
                //        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer1, document, sr2);

                //        ct2.AddElement((IElement)htmlarraylist2[k]);


                //    }
                //    ct2.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-5000), 10, Element.ALIGN_MIDDLE);
                //    ct2.Go();
                //}
                //catch(Exception ex)
                //{

                //}

                

             

                p++;

               
                PdfImportedPage importedPage = writer1.GetImportedPage(reader, page);

                cb.AddTemplate(importedPage, 0, 0);
                // stamper = document.CreatePageStamp(copiedPage);
                //cb.AddImage(L);



                BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.BeginText();
                cb.SetFontAndSize(bf1, 10);

                // cb.AddImage(L);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, p.ToString() , 570, 7, 0);
                cb.EndText();





            }



            document.Close();
        }


        //public class HtmlPageEventHelper : PdfPageEventHelper
        //{
        //    public HtmlPageEventHelper(string html)
        //    {
        //        this.html = html;
        //    }

        //    public override void OnEndPage(PdfWriter writer, Document document)
        //    {
        //        base.OnEndPage(writer, document);

        //        ColumnText ct = new ColumnText(writer.DirectContent);
        //        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(html));
        //        ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-20), 10, Element.ALIGN_MIDDLE);
        //        ct.Go();
        //    }

        //    string html = null;

        //    public object XMLWorkerHelper { get; private set; }
        //}
        //public class ColumnTextElementHandler : IElementHandler
        //{
        //    public ColumnTextElementHandler(ColumnText ct)
        //    {
        //        this.ct = ct;
        //    }

        //    ColumnText ct = null;

        //    public void Add(IWritable w)
        //    {
        //        if (w is WritableElement)
        //        {
        //            foreach (IElement e in ((WritableElement)w).Elements())
        //            {
        //                ct.AddElement(e);
        //            }
        //        }
        //    }
        //}

        //public void addpagenumber(string file1)
        //{

        //    //      String htmlText = "<font  " +
        //    //" color=\"#0000FF\"><b><i>Title One</i></b></font><font   " +
        //    //" color=\"black\"><br><br>Some text here<br><br><br><font   " +
        //    //" color=\"#0000FF\"><b><i>Another title here   " +
        //    //" </i></b></font><font   " +
        //    //" color=\"black\"><br><br>Text1<br>Text2<br><OL><LI>hi</LI><LI>how are u</LI></OL>";


        //    string htmlText = " <img style='width:147px;' src='http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png' /> ";
        //    List<IElement> htmlarraylist = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(htmlText), null);

        //    PdfReader reader = new PdfReader(file1);
        //    int n = reader.NumberOfPages;
        //    Rectangle psize = reader.GetPageSize(1);
        //    Document document = new Document(psize, 50, 50, 50, 50);
        //    //HTMLWorker htmlparser = new HTMLWorker(document);
        //   //StringReader sr = new StringReader(htmlText.ToString());
        //    PdfWriter writer1 = PdfWriter.GetInstance(document, new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf7.pdf", FileMode.Create));

        //    document.Open();




        //    PdfContentByte cb = writer1.DirectContent;

        //    //iTextSharp.text.pdf.PdfCopy.PageStamp stamper = null;

        //    int p = 0;
        //    Console.WriteLine("There are " + n + " pages in the document.");

        //    Image L = Image.GetInstance("http://lowen.activitystaging.com:81/pdfTemplate/img/logo.png");

        //    //L.SetAbsolutePosition(document.Left, document.Top - 180);

        //    for (int page = 1; page <= reader.NumberOfPages; page++)
        //    {

        //        for (int k = 0; k < htmlarraylist.Count; k++)
        //        {

        //            document.Add((IElement)htmlarraylist[k]);


        //        }


        //        document.NewPage();


        //        p++;

        //        // add text



        //        PdfImportedPage importedPage = writer1.GetImportedPage(reader, page);

        //        cb.AddTemplate(importedPage, 0, 0);
        //        // stamper = document.CreatePageStamp(copiedPage);
        //        //cb.AddImage(L);



        //        BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //        cb.BeginText();
        //        cb.SetFontAndSize(bf1, 10);

        //       // cb.AddImage(L);
        //        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, + p + "/" + n, 44, 7, 0);
        //        cb.EndText();





        //    }



        //    document.Close();
        //}

        ////private void GetClientAlertHtmlPdf(int Id, string pdfFileName, string apiUrl, bool downloadAsZipfile)
        ////{
        ////    StringBuilder sbHtmlText = new StringBuilder();

        ////    LogHelper.Debug<HtmlToPdfConversionController>(string.Format("PDF url: {0}", apiUrl));

        ////    /*apiUrl = baseUrl+"/pdfTemplate/bio.html";*/
        ////    WebClient webClient = new WebClient();
        ////    webClient.Encoding = Encoding.UTF8;
        ////    var textFromFile = webClient.DownloadString(apiUrl);

        ////    LogHelper.Debug<HtmlToPdfConversionController>(string.Format("PDF html text: {0}", textFromFile));

        ////    textFromFile = CleanUpXHTML(textFromFile);

        ////    textFromFile = textFromFile.Replace("<br>", "<br/>");
        ////    textFromFile = textFromFile.Replace("<BR>", "<br/>");
        ////    textFromFile = textFromFile.Replace("target=_blank", "");


        ////    // HtmlDocument document = new HtmlDocument();
        ////    //document.LoadHtml(textFromFile);

        ////    //textFromFile = document.DocumentNode.OuterHtml;
        ////    LogHelper.Debug<HtmlToPdfConversionController>(string.Format("PDF html text (clean): {0}", textFromFile));

        ////    //textFromFile =  textFromFile.ToString().Replace("<p><p>", "<p>").Replace("</p></p>", "</p>");
        ////    //textFromFile = textFromFile.ToString().Replace("<p> <p>", "<p>").Replace("</p> </p>", "</p>");
        ////    //textFromFile = textFromFile.ToString().Replace("<p> <p ", "<p").Replace("</p> </p>", "</p>");
        ////    //textFromFile = textFromFile.ToString().Replace("<p></p>", "");

        ////    //textFromFile = Regex.Replace(textFromFile, @"<(\w+)>(\s|&nbsp;)*</\1>", "");
        ////    //textFromFile = ConvertToAsciiString(textFromFile);

        ////    // System.Web.HttpContext.Current.Response.Write(textFromFile);
        ////    // System.Web.HttpContext.Current.Response.End();

        ////    StringReader sr = new StringReader(textFromFile);
        ////    float width = 612;
        ////    float height = 792;
        ////    var pgSize = new iTextSharp.text.Rectangle(width, height);
        ////    //Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 36, 36, 54, 54);
        ////    Document pdfDoc = new Document(pgSize, 34, 36, 34, 46);
        ////    if (!downloadAsZipfile)
        ////    {
        ////        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        ////        //open the stream 

        ////        //writer.PageEvent = new ITextEvents();
        ////        pdfDoc.Open();




        ////        writer.DirectContent.SetFontAndSize(GetFont("Roboto Condensed", "Roboto-Condensed.ttf").BaseFont, 14f);
        ////        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

        ////        writer.DirectContent.SetFontAndSize(GetFont("Roboto Condensed", "Roboto-Condensed.ttf").BaseFont, 14f);




        ////        PdfContentByte cb = writer.DirectContent;
        ////        ColumnText ct = new ColumnText(cb);
        ////        ct.Alignment = Element.ALIGN_JUSTIFIED;


        ////        string htmlText = "<div style='background-color:#575757;padding:10px 15px;'><p><strong>What You Need To Know:</strong></p><ol><li>Regulation A is being made available to all reporting companies.</li><li>The change will likely have the greatest benefit for smaller reporting companies.</li><li>The availability of Regulation A will make it easier for smaller reporting companies to raise capital as compared to current options.</li></ol><p></div>&nbsp;</p><p>On May 24, 2018, the Economic Growth, Regulatory Relief, and Consumer Protection Act was signed into law. While press coverage of the Act mostly focused on its rollback of regulations applicable to financial institutions and originating in the Dodd-Frank Wall Street Reform and Consumer Protection Act of 2010, significantly, the new Act also requires the U.S. Securities and Exchange Commission (SEC) to amend its rules to permit reporting companies to use Regulation A.</p><p>Regulation A provides an exemption from the registration provisions of the Securities Act of 1933, as amended (Securities Act), by permitting offerings of up to $20 million in any one-year period (Tier 1 Offerings) and offerings of up to $50 million in any one-year period (Tier 2 Offerings) subject to compliance with certain requirements. Until now, Regulation A has only been available to U.S. and Canadian issuers that were not subject to the reporting requirements of the Securities Exchange Act of 1934, as amended (Exchange Act). However, the new law orders the SEC to remove this eligibility requirement, making Regulation A available to all reporting companies, and mandates that the ongoing reporting obligations associated with Tier 2 Offerings are satisfied by Exchange Act reporting (which a public company already does).</p><p><span class='arial_12'><strong>What This May Mean for Smaller Public Companies</strong></span></p><p>There are three significant advantages that this expansion of Regulation A is expected to have for smaller companies that are already public.</p><p>First, reporting companies that do not trade on national securities exchanges (for example, those that trade in the over-the-counter markets) will be able to avoid state securities law requirements by conducting future offerings in compliance with Tier 2 of Regulation A.</p><p>Second, Regulation A permits issuers to do significant investor outreach prior to submitting an offering statement to the SEC, including solicitations of written indications of interest. That outreach will enable smaller reporting companies to gauge investor interest in their securities by contacting retail as well as institutional investors before committing to the expense of preparing an offering circular.</p><p>Third, Regulation A will allow smaller public companies to make offerings to retail investors through a general solicitation without having to comply with the burdensome income verification requirements of Rule 506(c) under Regulation D.</p><p><strong>Offerings Off-the-Shelf</strong></p><p>Rule 251(d)(3) of Regulation A permits certain offerings to be made on a delayed or continuous basis pursuant to a qualified offering statement.&nbsp; However, as currently written, Rule 251(d)(3) would not permit an issuer to conduct a delayed primary offering “off-the-shelf”.&nbsp; In the spirit of the legislation, the SEC may decide to expand Rule 251(d)(3) to permit shelf offerings to expand the utility of Regulation A and bring it into closer conformity with Rule 415.&nbsp; However, if the SEC elects to do so, it may impose restrictions on such offerings, including limitations on which issuers can use any shelf offering procedure and limitations on the amount that may be sold, similar to those contained in the “baby shelf” rule in General Instruction I.B.6. to Form S-3.</p><p><strong>Eligibility</strong></p><p>Regulation A is not available to certain issuers, such as companies organized outside the U.S. and Canada; shell companies; investment companies; issuers of interests in oil, gas and other mineral rights; issuers of asset-backed securities; issuers that have had their securities denied or suspended from registration by the SEC within the past five years; and issuers that are disqualified by any “bad actor” events involving the issuer or any of its affiliates. However, this expansion of Regulation A is likely to provide significant relief to qualifying smaller reporting companies.</p><p><em>The full text of S.2155, Economic Growth, Regulatory Relief, and Consumer Protection Act is available<span>&nbsp;</span><a rel='noopener noreferrer' href='https://www.congress.gov/bill/115th-congress/senate-bill/2155' target='_blank'>here</a>.</em></p>";
        ////        Paragraph par = new Paragraph();
        ////        //ColumnText c1 = new ColumnText(contentBtye);
        ////        List<IElement> elements = HTMLWorker.ParseToList(new StringReader(htmlText), null);

        ////        List unorderlist = new List(List.UNORDERED);

        ////        unorderlist.Add(new ListItem("One"));

        ////        unorderlist.Add("Two");

        ////        unorderlist.Add("Three");

        ////        unorderlist.Add("Four");

        ////        unorderlist.Add("Five");

        ////        foreach (IElement element in elements)
        ////        {
        ////            par.Add(element);
        ////        }

        ////        ct.AddText(par);



        ////        float gutter = 10f;
        ////        float colwidth = (pdfDoc.Right - pdfDoc.Left - gutter) / 2;
        ////        float[] left = { pdfDoc.Left  , pdfDoc.Top ,
        ////          pdfDoc.Left ,pdfDoc.Bottom };

        ////        float[] right = { pdfDoc.Left + colwidth, pdfDoc.Top - 80f,
        ////          pdfDoc.Left + colwidth, pdfDoc.Bottom };

        ////        float[] left2 = { pdfDoc.Right - colwidth, pdfDoc.Top - 80f,
        ////          pdfDoc.Right - colwidth, pdfDoc.Bottom };

        ////        float[] right2 = {pdfDoc.Right, pdfDoc.Top - 80f,
        ////          pdfDoc.Right, pdfDoc.Bottom };

        ////        int status = 0;
        ////        int i = 0;
        ////        int j = 1;
        ////        //Checks the value of status to determine if there is more text
        ////        //If there is, status is 2, which is the value of NO_MORE_COLUMN
        ////        while (ColumnText.HasMoreText(status))
        ////        {
        ////            if (i == 0)
        ////            {
        ////                //Writing the first column
        ////                ct.SetColumns(left, right);
        ////                i++;
        ////            }
        ////            else
        ////            {
        ////                //write the second column
        ////                ct.SetColumns(left2, right2);

        ////            }
        ////            //Needs to be here to prevent app from hanging
        ////            ct.YLine = pdfDoc.Top - 80f;
        ////            //Commit the content of the ColumnText to the document
        ////            //ColumnText.Go() returns NO_MORE_TEXT (1) and/or NO_MORE_COLUMN (2)
        ////            //In other words, it fills the column until it has either run out of column, or text, or both
        ////            status = ct.Go();

        ////            if (j % 2 == 0)
        ////            {
        ////                pdfDoc.NewPage();
        ////                i = 0;
        ////            }

        ////            j++;



        ////        }


        ////        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        ////        PdfPCell cell;

        ////        tabFot.KeepTogether = true;
        ////        tabFot.HorizontalAlignment = Element.ALIGN_CENTER;

        ////        tabFot.TotalWidth = 515;
        ////        tabFot.LockedWidth = true;
        ////        Paragraph text = new Paragraph("NEW YORK      PALO ALTO      NEW JERSEY      UTAH      WASHINGTON, D.C. \n \n \u00A9 " + DateTime.Now.ToString("yyyy") + " Lowenstein Sandler LLP", FontFactory.GetFont("Roboto Condensed", 9, Font.NORMAL, iTextSharp.text.BaseColor.GRAY));
        ////        text.Alignment = Element.ALIGN_CENTER;
        ////        cell = new PdfPCell(new Phrase(text));
        ////        cell.Border = 1;
        ////        cell.BorderColorTop = BaseColor.GRAY;
        ////        cell.PaddingTop = 7f;
        ////        cell.PaddingBottom = 5f;
        ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        ////        tabFot.AddCell(cell);

        ////        tabFot.WriteSelectedRows(0, -1, 40, pdfDoc.Bottom, writer.DirectContent);



        ////        pdfDoc.Close();
        ////        Response.ContentType = "application/pdf";
        ////        Response.AddHeader("content-disposition", "attachment;filename=" + pdfFileName);
        ////        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        ////        Response.Write(pdfDoc);
        ////        Response.End();
        ////    }
        ////    else
        ////    {


        ////        using (FileStream fs = new FileStream(Server.MapPath("~/pdfTemplate/temp/") + pdfFileName, FileMode.Create))
        ////        {

        ////            using (iTextSharp.text.Document doc = new iTextSharp.text.Document())
        ////            {
        ////                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
        ////                //open the stream 

        ////                //writer.PageEvent = new ITextEvents();
        ////                pdfDoc.Open();

        ////                //Path to our font
        ////                // string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
        ////                //Register the font with iTextSharp
        ////                // FontFactory.Register(arialuniTff);


        ////                writer.DirectContent.SetFontAndSize(GetFont("Roboto Condensed", "Roboto-Condensed.ttf").BaseFont, 14f);
        ////                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);


        ////                writer.DirectContent.SetFontAndSize(GetFont("Roboto Condensed", "Roboto-Condensed.ttf").BaseFont, 14f);
        ////                PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        ////                PdfPCell cell;
        ////                tabFot.HorizontalAlignment = Element.ALIGN_CENTER;

        ////                tabFot.TotalWidth = 515;
        ////                tabFot.LockedWidth = true;
        ////                Paragraph text = new Paragraph("NEW YORK      PALO ALTO      NEW JERSEY      UTAH      WASHINGTON, D.C. \n \n \u00A9 " + DateTime.Now.ToString("yyyy") + " Lowenstein Sandler LLP", FontFactory.GetFont("Roboto Condensed", 9, Font.NORMAL, iTextSharp.text.BaseColor.GRAY));
        ////                text.Alignment = Element.ALIGN_CENTER;
        ////                cell = new PdfPCell(new Phrase(text));
        ////                cell.Border = 1;
        ////                cell.BorderColorTop = BaseColor.GRAY;
        ////                cell.PaddingTop = 7f;
        ////                cell.PaddingBottom = 5f;
        ////                cell.HorizontalAlignment = Element.ALIGN_CENTER;
        ////                tabFot.AddCell(cell);

        ////                tabFot.WriteSelectedRows(0, -1, 40, pdfDoc.Bottom, writer.DirectContent);


        ////                pdfDoc.Close();
        ////            }
        ////            fs.Close();
        ////        }
        ////    }





        ////}

        private object GetFont(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        // Normal Pdf
        //public ActionResult ItextSharpPdfGen()
        //{

        //   // string pdfpath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs");

        //   // string imagepath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\Columns");

        //    Document doc = new Document();

        //    try

        //    {

        //        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\Columns.pdf", FileMode.Create));

        //        doc.Open();

        //        Paragraph heading = new Paragraph("Page Heading", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 28f, iTextSharp.text.Font.BOLD));

        //        heading.SpacingAfter = 18f;

        //        doc.Add(heading);

        //        string text = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?";


        //        PdfContentByte cb = writer.DirectContent;
        //        MultiColumnText columns = new MultiColumnText();
        //        //ColumnText colums = new ColumnText(cb);

        //        //float left, float right, float gutterwidth, int numcolumns

        //        //columns.AddRegularColumns(36f, doc.PageSize.Width - 36f, 24f, 2);



        //        Paragraph para = new Paragraph(text, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f));

        //        para.SpacingAfter = 9f;

        //        para.Alignment = Element.ALIGN_JUSTIFIED;

        //        //for (int i = 0; i < 8; i++)

        //        //{

        //        //    columns.AddElement(para);

        //        //}

        //        doc.Add(para);


        //       // doc.AddElement(colums);



        //    }

        //    catch (Exception ex)

        //    {

        //        //Log(ex.Message);

        //    }

        //    finally

        //    {

        //        doc.Close();

        //    }

        //    return View();
        //}


        //public ActionResult ItextSharpPdfGen()
        //{
        //    string pdfpath = Server.MapPath("PDFs");

        //    string imagepath = Server.MapPath("Images");

        //    Document doc = new Document();

        //    try

        //    {

        //        //PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Columns.pdf", FileMode.Create));

        //        doc.Open();

        //        Paragraph heading = new Paragraph("Page Heading", new Font(Font.FontFamily.HELVETICA, 28f, Font.BOLD));

        //        heading.SpacingAfter = 18f;

        //        doc.Add(heading);

        //        string text = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?";

        //        FileStream output = new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\New1.pdf", FileMode.Create);

        //        PdfWriter writer = PdfWriter.GetInstance(doc, output);

        //        doc.Open();

        //        PdfContentByte cb = writer.DirectContent;

        //        ColumnText ct = new ColumnText(cb);





        //        Paragraph para = new Paragraph(text, new Font(Font.FontFamily.HELVETICA, 8f));

        //        para.SpacingAfter = 9f;

        //        para.Alignment = Element.ALIGN_JUSTIFIED;



        //        PdfPTable table = new PdfPTable(3);

        //        float[] widths = new float[] { 1f, 1f, 1f };

        //        table.TotalWidth = 300f;

        //        table.LockedWidth = true;

        //        table.SetWidths(widths);

        //        PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

        //        cell.Colspan = 3;

        //        cell.HorizontalAlignment = 0;

        //        table.AddCell(cell);

        //        table.AddCell("Col 1 Row 1");

        //        table.AddCell("Col 2 Row 1");

        //        table.AddCell("Col 3 Row 1");

        //        table.AddCell("Col 1 Row 2");

        //        table.AddCell("Col 2 Row 2");

        //        table.AddCell("Col 3 Row 2");



        //        Image jpg = Image.GetInstance("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\leader1.jpg");

        //        jpg.ScaleToFit(300f, 300f);

        //        jpg.SpacingAfter = 12f;

        //        jpg.SpacingBefore = 12f;



        //        ct.AddElement(para);

        //        ct.AddElement(table);

        //        ct.AddElement(jpg);

        //        ct.AddElement(para);

        //        ct.AddElement(para);

        //        ct.AddElement(para);

        //        ct.AddElement(para);

        //        ct.Go();


        //    }

        //    catch (Exception ex)

        //    {

        //        //Log(ex.Message);

        //    }

        //    finally

        //    {

        //        doc.Close();

        //    }

        //    return View();
        //}


        //working pdf css
        public ActionResult GenerateClientPdf()
        {
            return View();
        }
        public ActionResult ItextSharpPdfGen()
        {

            // string pdfpath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs");

            // string imagepath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\Columns");

         
            FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");

            float width = 612;
            float height = 792;
            var pgSize = new iTextSharp.text.Rectangle(width, height);

            Document doc = new Document(pgSize, 34f, 36f, 34f, 46f);
            // iTextSharp.text.Font font1 = new iTextSharp.text.Font(FontFamil(Color.Gray));
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13f);
           // doc.SetMargins(PageSize.A4, 45f, 45f, 60f, 60f);
            try
            {
                FileStream output = new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\lawnston.pdf", FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, output);
                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                ColumnText ct = new ColumnText(cb);
                ct.Alignment = Element.ALIGN_JUSTIFIED;
                string htmlText = "<p>In a much-awaited decision, the Supreme Court finally resolved the longstanding split among the circuit courts regarding the applicability of the “settlement payment defense” under 546(e) of the Bankruptcy Code (<em>the Settlement Payment Defense</em>). The <em>Merit Management</em><sup>1</sup> Court’s focus on § 546(e)’s scope should ease the minds of those who worried the Supreme Court would limit the Bankruptcy Code’s definition of a “financial institution.”<sup>2</sup></p><p><strong>1. THE SETTLEMENT PAYMENT DEFENSE</strong></p><p>The Settlement Payment Defense shields covered entities from constructive fraudulent conveyance actions by precluding a trustee from recovering a “settlement payment” or “transfer” made “by or to (or for the benefit of)” these entities, including financial institutions. Many defendant-transferees raise the Settlement Payment Defense to protect their received settlement payments.</p><p><img src='/media/4199/lowen_8.jpg' alt='' data-udi='umb://media/1f42c95143974488b0ef8025e07beb34' /></p><p>Venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi.</p><hr style='border: 0; color: #000; background-color: #000; height: 0.9px;' /><p><strong>2. PRE-<em>MERIT MANAGEMENT</em> CIRCUIT SPLIT</strong></p><p>Prior to the <em>Merit Management</em> decision, circuit courts had two views on the reach of the Settlement Payment Defense. One view (the <em>Plurality View</em>), subscribed to by five circuit courts, allowed the existence of a financial institution in the chain of transfers to insulate subsequent transferees from liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense.</p><p>The Seventh Circuit proposed a different view (<em>the Seventh Circuit View</em>), which looked at the transaction as a whole and focused on the ultimate transferee. Namely, the Seventh Circuit held that the Settlement Payment Defense did not apply when the only covered entity is the financial institution that served as a mere conduit for the distribution of payment to the transferee.</p><p>In <em>Merit Management</em>, one side argued in favor of the Plurality View, and the other asserted that the Seventh Circuit View applies.</p><p><img src='/media/4200/lowen_9.jpg' alt='' /></p><p>Sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh.</p><p><strong>3. BRIEF FACTS IN <em>MERIT MANAGEMENT</em></strong></p><p>The <em>Merit Management</em> case involved a chapter 11 trustee (the Trustee) that identified what it considered to be a constructive fraudulent transfer from the Debtor to a transferee (the Transferee). The Trustee alleged that the Debtor purchased stock from the Transferee at a price that did not provide fair value.<sup>3</sup> Therefore, the Trustee filed suit to recover (“avoid”) the allegedly dubious pre-petition payments.</p><p>The Transferee filed a motion on the pleadings, whereby it argued that the Settlement Payment Defense barred the Trustee from recovery pursuant to the Plurality View. Specifically, the Transferee argued that the Settlement Payment Defense insulated the relevant transaction from scrutiny, because the final payment to the Transferee was not made by the Debtor, but rather “by” a protected intermediary: a financial institution that served as a conduit for the transfer of payment. The Trustee countered with the Seventh Circuit View: the Settlement Payment Defense cannot be used to insulate transfers that were made through a financial institution but did not involve said financial institution as a direct party.</p><p>The Supreme Court agreed with the Trustee, but on broader grounds.</p><p><strong>4. THE <em>MERIT MANAGEMENT</em> HOLDING</strong></p><p>The <em>Merit Management</em> Court did not did limit the definition of a “financial institution” in any way. Instead, it simply held that when considering the Settlement Payment Defense, courts are to concentrate on the overarching transaction from initial transferor to end transferee, and not on the component parts.</p><p>Focusing its discussion on this general holding, the <em>Merit Management</em> Court clarified that using a financial institution as a mere conduit for the distribution of funds does not shield a transaction from avoidance actions. Essentially, courts should “look to the transfer that the trustee seeks to avoid (i.e., A ➝ D) to determine whether” the Settlement Payment Defense insulates said transfer, and should not look to the “component parts of the overarching transfer (i.e., A ➝ B ➝ C ➝ D).”<sup>4</sup></p><p>The Supreme Court did not discuss whether the Debtor or the Transferee qualified as a “financial institution.” Thus, despite <em>Merit Management’s</em> holding, defendants can still avail themselves of the Settlement Payment Defense if they claim “financial institution” status as part of their defense.</p><p><strong>5. POST-<em>MERIT MANAGEMENT</em> IMPLICATIONS</strong></p><p>While the decision will deprive some avoidance defendants of the ability to use the Settlement Payment Defense, said defense still applies when the financial institution asserting the Settlement Payment Defense is the conduit-bank’s “customer.” The <em>Merit Management</em> ruling did not limit the Bankruptcy Code’s definition of a “financial institution.” As previously stated, the Settlement Payment Defense precludes a trustee from avoiding a “settlement payment” or “transfer” made “by or to (or for the benefit of)” “financial institutions.”</p><p>The Bankruptcy Code’s definition of “financial institutions” includes the “customer” of certain banks or commercial entities when a bank or commercial entity acts as an agent or custodian for the customer in connection with a securities contract.<sup>5</sup> Hypothetically speaking, a transferee that is also a customer of a bank or commercial entity serving as an intermediary to a transaction could use the Settlement Payment Defense to insulate itself from an avoidance action, given that the Bankruptcy Code also defines said customer as a protected “financial institution.”</p><p>At the <em>Merit Management</em> oral argument, Justice Stephen Breyer suggested that this might be a valid justification for transferees to continue using the Settlement Payment Defense.<sup>6</sup> However, the Court chose to not discuss the Bankruptcy Code’s definition of a “financial institution,” as the Transferee conceded the aforementioned point in the lower courts. Thus, it still remains true that a financial institution may avail itself of the Settlement Payment Defense if it is one of the transacting parties, as opposed to an intermediary.</p><p>Given this development, the main takeaway for securities market participants is that they must demand a detailed transfer structure that gives them “financial institution” status in order to curtail avoidance liability. Many circuit courts are mindful of the importance of financial market stability and certainty, and the detrimental effects that would result from subjecting all securities transactions to avoidance actions. By insisting on a transfer structure whereby transferees fit within the Bankruptcy Code’s definition of a “financial institution,” market participants will safeguard their securities transactions from avoidance risk.</p><p><strong>6. CONCLUSION</strong></p><p>Focusing its attention on <em>Merit Management’s</em> specific facts, the Supreme Court’s ruling appears to leave in place protections for certain shareholders receiving settlement payments under securities contracts. Going forward, market participants that seek certainty and finality in their transactions will be wise to ensure that they qualify for “financial institution” status prior to entering into a securities transaction.</p><p>The Supreme Court agreed with the Trustee, but on broader grounds.</p><p> </p><p><sup>1</sup> <em>Merit Mgmt. Grp., LP v. FTI Consulting, Inc.,</em> No. 16-784, 2018 WL 1054879 (U.S. Feb. 27, 2018).</p><p><sup>2</sup> 11 U.S.C. § 101(22).<br /> <sup>3</sup> The Bankruptcy Code allows a trustee to seek the avoidance of fraudulent transfers. 11 U.S.C. § 548(a).<br /> <sup>4</sup> <em>Merit Mgmt. Grp.,</em> 2018 WL 1054879, at *3, 12.<br /> <sup>5</sup> 11 U.S.C. § 101(22).<br /> <sup>6</sup> See Transcript of Oral Argument at 13-20, <em>Merit Mgmt. Grp., LP v. FTI Consulting, Inc.,</em> No. 16-784, 2018 WL 1054879 (U.S. Feb. 27, 2018) (available <a href='http://lowen.activitystaging.com:81/news-insights/client-alerts/lessons-from-merit-management-the-settlement-payment-defense-lives-if-you-are-a-financial-institution'>here</a>).</p>";

                var elements = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(htmlText, null);
             
                List<string> list = new List<string>();
                Paragraph paragraph1 = new Paragraph();
                RomanList romanlist = new RomanList(true, 20);
                foreach (var es in elements)
                {

                    if (es.Type == 14)
                    {
                        for (int k = 0; k < es.Chunks.Count; k++)
                        {
                            string str = es.Chunks[k].Content.ToString();
                         
                            list.Add(str);
                           
                        }

                        for (int m = 0; m < list.Count; m++)
                        {
                            ct.AddText(new Phrase(string.Concat("     ", (m + 1), ".  ")));
                            ct.AddText(new Phrase(list[m]));
                            if (m != list.Count - 1)
                                ct.AddText(Chunk.NEWLINE);


                        }
                    

                    }
                    else
                    {
                        StringReader sr = new StringReader(es.ToString());
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

                        var paragraph = new Paragraph();
                        ct.SetSimpleColumn(paragraph, 80, 460, 475, 0, 15, Element.ALIGN_LEFT);
                        paragraph.Add(es);
                        ct.AddText(paragraph);
                        paragraph.Add(Chunk.NEWLINE);
                    }
                }


            

                float gutter = 15f;
                float colwidth = (doc.Right - doc.Left - gutter) / 2;
               
                float[] left = {  doc.Left + 10f, doc.Top - 10f,
         doc.Left + 10f, doc.Bottom };

                float[] right = { doc.Left + colwidth, doc.Top - 10f,
        doc.Left + colwidth, doc.Bottom };

                float[] left2 = { doc.Right - colwidth, doc.Top - 10f,
        doc.Right - colwidth, doc.Bottom };

                float[] right2 = {doc.Right, doc.Top - 10f,
        doc.Right, doc.Bottom };

                int status = 0;
                int i = 0;
                int j = 1;
                //Checks the value of status to determine if there is more text
                //If there is, status is 2, which is the value of NO_MORE_COLUMN
                while (ColumnText.HasMoreText(status))
                {
                    if (i == 0)
                    {
                        //Writing the first column
                        ct.SetColumns(left, right);
                        i++;
                    }
                    else
                    {
                        //write the second column
                        ct.SetColumns(left2, right2);

                    }
                    //Needs to be here to prevent app from hanging
                    ct.YLine = doc.Top - 20f;
                    //Commit the content of the ColumnText to the document
                    //ColumnText.Go() returns NO_MORE_TEXT (1) and/or NO_MORE_COLUMN (2)
                    //In other words, it fills the column until it has either run out of column, or text, or both
                    status = ct.Go();

                    if (j % 2 == 0)
                    {
                        doc.NewPage();
                        i = 0;
                    }

                    j++;



                }
            }
            catch (Exception ex)
            {
                //Log(ex.Message);
            }
            finally
            {
                doc.Close();
            }

            return View();
        }

        public ActionResult Pdffile()
        {
            return View();
        }



        public ActionResult ItextSharpPdfMulti()
        {
            string pdfpath = Server.MapPath("PDFs");

            string imagepath = Server.MapPath("Columns");

            Document doc = new Document();

            //Font font1 = new Font(FontFactory.GetFont("adobe garamond pro", 36f, iTextSharp.text.Font.Color.GRAY));

            Font font2 = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9f);

            doc.SetMargins(45f, 45f, 60f, 60f);

            try

            {

                FileStream output = new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\split.pdf", FileMode.Create);

                PdfWriter writer = PdfWriter.GetInstance(doc, output);

                doc.Open();

                PdfContentByte cb = writer.DirectContent;
                ColumnText ct = new ColumnText(cb);

                ct.Alignment = Element.ALIGN_JUSTIFIED;



                Paragraph heading = new Paragraph("Chapter 1", font2);

                heading.Leading = 40f;

                doc.Add(heading);


               // var sampleTable = "<table><tr><td>A</td><td>B</td><td>C</td><td>D</td></tr></table>";

                string sampleTable = "<html><head><title>Page Title</title><style>body { column-width: 12em;column-count: 2;column-gap: 3em;}</style></head><body><table border='0' cellpadding='0' cellspacing='0' width='100%' class='pdfmaincontent'> <tbody><tr> <td width='100%' valign='top' height='25'> <p>In a much-awaited decision, the Supreme Court finally resolved the longstanding split among the circuit courts regarding the applicability of the “settlement payment defense” under 546(e) of the Bankruptcy Code (<em>the Settlement Payment Defense</em>). The <em>Merit Management</em><sup>1</sup> Court’s focus on § 546(e)’s scope should ease the minds of those who worried the Supreme Court would limit the Bankruptcy Code’s definition of a “financial institution.”<sup>2</sup></p><p><strong>1. THE SETTLEMENT PAYMENT DEFENSE</strong></p><p>The Settlement Payment Defense shields covered entities from constructive fraudulent conveyance actions by precluding a trustee from recovering a “settlement payment” or “transfer” made “by or to (or for the benefit of)” these entities, including financial institutions. Many defendant-transferees raise the Settlement Payment Defense to protect their received settlement payments.</p><p><img src='http://localhost:53312//media/4199/lowen_8.jpg' alt='' data-udi='umb://media/1f42c95143974488b0ef8025e07beb34'></p><p>Venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi.</p><hr style='border: 0; color: #000; background-color: #000; height: 0.9px;'><p><strong>2. PRE-<em>MERIT MANAGEMENT</em> CIRCUIT SPLIT</strong></p><p>Prior to the <em>Merit Management</em> decision, circuit courts had two views on the reach of the Settlement Payment Defense. One view (the <em>Plurality View</em>), subscribed to by five circuit courts, allowed the existence of a financial institution in the chain of transfers to insulate subsequent transferees from liability. While the defendant, typically the transaction’s ultimate transferee, is not a covered entity, the financial institution that makes the final payment to said transferee usually is. Thus, the theory goes that if one of the component parts to the transaction is a covered entity, the whole transaction is protected by the Settlement Payment Defense.</p><p>The Seventh Circuit proposed a different view (<em>the Seventh Circuit View</em>), which looked at the transaction as a whole and focused on the ultimate transferee. Namely, the Seventh Circuit held that the Settlement Payment Defense did not apply when the only covered entity is the financial institution that served as a mere conduit for the distribution of payment to the transferee.</p><p>In <em>Merit Management</em>, one side argued in favor of the Plurality View, and the other asserted that the Seventh Circuit View applies.</p><p><img src='http://localhost:53312//media/4200/lowen_9.jpg' alt=''></p><p>Sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh.</p><p><strong>3. BRIEF FACTS IN <em>MERIT MANAGEMENT</em></strong></p><p>The <em>Merit Management</em> case involved a chapter 11 trustee (the Trustee) that identified what it considered to be a constructive fraudulent transfer from the Debtor to a transferee (the Transferee). The Trustee alleged that the Debtor purchased stock from the Transferee at a price that did not provide fair value.<sup>3</sup> Therefore, the Trustee filed suit to recover (“avoid”) the allegedly dubious pre-petition payments.</p><p>The Transferee filed a motion on the pleadings, whereby it argued that the Settlement Payment Defense barred the Trustee from recovery pursuant to the Plurality View. Specifically, the Transferee argued that the Settlement Payment Defense insulated the relevant transaction from scrutiny, because the final payment to the Transferee was not made by the Debtor, but rather “by” a protected intermediary: a financial institution that served as a conduit for the transfer of payment. The Trustee countered with the Seventh Circuit View: the Settlement Payment Defense cannot be used to insulate transfers that were made through a financial institution but did not involve said financial institution as a direct party.</p><p>The Supreme Court agreed with the Trustee, but on broader grounds.</p><p><strong>4. THE <em>MERIT MANAGEMENT</em> HOLDING</strong></p><p>The <em>Merit Management</em> Court did not did limit the definition of a “financial institution” in any way. Instead, it simply held that when considering the Settlement Payment Defense, courts are to concentrate on the overarching transaction from initial transferor to end transferee, and not on the component parts.</p><p>Focusing its discussion on this general holding, the <em>Merit Management</em> Court clarified that using a financial institution as a mere conduit for the distribution of funds does not shield a transaction from avoidance actions. Essentially, courts should “look to the transfer that the trustee seeks to avoid (i.e., A ➝ D) to determine whether” the Settlement Payment Defense insulates said transfer, and should not look to the “component parts of the overarching transfer (i.e., A ➝ B ➝ C ➝ D).”<sup>4</sup></p><p>The Supreme Court did not discuss whether the Debtor or the Transferee qualified as a “financial institution.” Thus, despite <em>Merit Management’s</em> holding, defendants can still avail themselves of the Settlement Payment Defense if they claim “financial institution” status as part of their defense.</p><p><strong>5. POST-<em>MERIT MANAGEMENT</em> IMPLICATIONS</strong></p><p>While the decision will deprive some avoidance defendants of the ability to use the Settlement Payment Defense, said defense still applies when the financial institution asserting the Settlement Payment Defense is the conduit-bank’s “customer.” The <em>Merit Management</em> ruling did not limit the Bankruptcy Code’s definition of a “financial institution.” As previously stated, the Settlement Payment Defense precludes a trustee from avoiding a “settlement payment” or “transfer” made “by or to (or for the benefit of)” “financial institutions.”</p><p>The Bankruptcy Code’s definition of “financial institutions” includes the “customer” of certain banks or commercial entities when a bank or commercial entity acts as an agent or custodian for the customer in connection with a securities contract.<sup>5</sup> Hypothetically speaking, a transferee that is also a customer of a bank or commercial entity serving as an intermediary to a transaction could use the Settlement Payment Defense to insulate itself from an avoidance action, given that the Bankruptcy Code also defines said customer as a protected “financial institution.”</p><p>At the <em>Merit Management</em> oral argument, Justice Stephen Breyer suggested that this might be a valid justification for transferees to continue using the Settlement Payment Defense.<sup>6</sup> However, the Court chose to not discuss the Bankruptcy Code’s definition of a “financial institution,” as the Transferee conceded the aforementioned point in the lower courts. Thus, it still remains true that a financial institution may avail itself of the Settlement Payment Defense if it is one of the transacting parties, as opposed to an intermediary.</p><p>Given this development, the main takeaway for securities market participants is that they must demand a detailed transfer structure that gives them “financial institution” status in order to curtail avoidance liability. Many circuit courts are mindful of the importance of financial market stability and certainty, and the detrimental effects that would result from subjecting all securities transactions to avoidance actions. By insisting on a transfer structure whereby transferees fit within the Bankruptcy Code’s definition of a “financial institution,” market participants will safeguard their securities transactions from avoidance risk.</p><p><strong>6. CONCLUSION</strong></p><p>Focusing its attention on <em>Merit Management’s</em> specific facts, the Supreme Court’s ruling appears to leave in place protections for certain shareholders receiving settlement payments under securities contracts. Going forward, market participants that seek certainty and finality in their transactions will be wise to ensure that they qualify for “financial institution” status prior to entering into a securities transaction.</p><p>The Supreme Court agreed with the Trustee, but on broader grounds.</p><p>&nbsp;</p><p><sup>1</sup> <em>Merit Mgmt. Grp., LP v. FTI Consulting, Inc.,</em> No. 16-784, 2018 WL 1054879 (U.S. Feb. 27, 2018).</p><p><sup>2</sup> 11 U.S.C. § 101(22).<br> <sup>3</sup> The Bankruptcy Code allows a trustee to seek the avoidance of fraudulent transfers. 11 U.S.C. § 548(a).<br> <sup>4</sup> <em>Merit Mgmt. Grp.,</em> 2018 WL 1054879, at *3, 12.<br> <sup>5</sup> 11 U.S.C. § 101(22).<br> <sup>6</sup> See Transcript of Oral Argument at 13-20, <em>Merit Mgmt. Grp., LP v. FTI Consulting, Inc.,</em> No. 16-784, 2018 WL 1054879 (U.S. Feb. 27, 2018) (available <a href='http://lowen.activitystaging.com:81/news-insights/client-alerts/lessons-from-merit-management-the-settlement-payment-defense-lives-if-you-are-a-financial-institution'>here</a>).</p> </td> </tr> </tbody></table></body></html>";
                //Parse sample HTML to collection if IElement objects
                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(sampleTable), null);

                //Declare variables for use below
                IElement ele;
                PdfPTable t;

                //Loop through the collection
                for (int k = 0; k < htmlarraylist.Count; k++)
                {

                    //Get the individual item (no cast should be needed)
                    ele = htmlarraylist[k];

                    //If the item is a PdfPTable
                    if (ele is PdfPTable)
                    {

                        //Get and cast it
                        t = ele as PdfPTable;

                        //Set the widths (40%/20%/20%/20%)
                        t.SetWidths(new float[] { 4, 2, 2, 2 });

                    }

                    //Regardless of what was done above, add the object to our document
                    doc.Add(ele);
                

                    }

            }

            catch (Exception ex)

            {

                //Log(ex.Message);

            }

            finally
    
            {

                doc.Close();

            }

            return View();


        }

           

          
       



        ////public ActionResult ItextSharpPdfGen()
        ////{

        ////    // string pdfpath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs");

        ////    // string imagepath = Server.MapPath("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\Columns");

        ////    string pdfpath = Server.MapPath("PDFs");
        ////    //string imagepath = Server.MapPath("Images");
        ////    FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");

        ////    Document doc = new Document();


        ////    // iTextSharp.text.Font font1 = new iTextSharp.text.Font(FontFamil(Color.Gray));
        ////    iTextSharp.text.Font font1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f);
        ////    iTextSharp.text.Font font2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13f);
        ////    doc.SetMargins(45f, 45f, 60f, 60f);
        ////    try
        ////    {
        ////        FileStream output = new FileStream("C:\\inetpub\\wwwroot\\FirstProject\\PDF\\PDFs\\NewPdf.pdf", FileMode.Create);
        ////        PdfWriter writer = PdfWriter.GetInstance(doc, output);

        ////        doc.Open();
        ////        PdfContentByte cb = writer.DirectContent;
        ////        ColumnText ct = new ColumnText(cb);
        ////        ct.Alignment = Element.ALIGN_JUSTIFIED;

        ////        Paragraph heading = new Paragraph("Chapter 1", font1);
        ////        heading.Leading = 40f;
        ////        doc.Add(heading);





        ////        //string htmlText = "<style>p{font-size:10px;color:#0000FF;}</style><p><strong>What You Need To Know:</strong></p><img src='/1.jpg' /><ul><li>Regulation A is being made available to all reporting companies.</li><li>The change will likely have the greatest benefit for smaller reporting companies.</li><li>The availability of Regulation A will make it easier for smaller reporting companies to raise capital as compared to current options.</li></ul><p>&nbsp;</p><p>On May 24, 2018, the Economic Growth, Regulatory Relief, and Consumer Protection Act was signed into law. While press coverage of the Act mostly focused on its rollback of regulations applicable to financial institutions and originating in the Dodd-Frank Wall Street Reform and Consumer Protection Act of 2010, significantly, the new Act also requires the U.S. Securities and Exchange Commission (SEC) to amend its rules to permit reporting companies to use Regulation A.</p><p>Regulation A provides an exemption from the registration provisions of the Securities Act of 1933, as amended (Securities Act), by permitting offerings of up to $20 million in any one-year period (Tier 1 Offerings) and offerings of up to $50 million in any one-year period (Tier 2 Offerings) subject to compliance with certain requirements. Until now, Regulation A has only been available to U.S. and Canadian issuers that were not subject to the reporting requirements of the Securities Exchange Act of 1934, as amended (Exchange Act). However, the new law orders the SEC to remove this eligibility requirement, making Regulation A available to all reporting companies, and mandates that the ongoing reporting obligations associated with Tier 2 Offerings are satisfied by Exchange Act reporting (which a public company already does).</p><p><span class='arial_12'><strong>What This May Mean for Smaller Public Companies</strong></span></p><p>There are three significant advantages that this expansion of Regulation A is expected to have for smaller companies that are already public.</p><p>First, reporting companies that do not trade on national securities exchanges (for example, those that trade in the over-the-counter markets) will be able to avoid state securities law requirements by conducting future offerings in compliance with Tier 2 of Regulation A.</p><p>Second, Regulation A permits issuers to do significant investor outreach prior to submitting an offering statement to the SEC, including solicitations of written indications of interest. That outreach will enable smaller reporting companies to gauge investor interest in their securities by contacting retail as well as institutional investors before committing to the expense of preparing an offering circular.</p><p>Third, Regulation A will allow smaller public companies to make offerings to retail investors through a general solicitation without having to comply with the burdensome income verification requirements of Rule 506(c) under Regulation D.</p><p><strong>Offerings Off-the-Shelf</strong></p><p>Rule 251(d)(3) of Regulation A permits certain offerings to be made on a delayed or continuous basis pursuant to a qualified offering statement.&nbsp; However, as currently written, Rule 251(d)(3) would not permit an issuer to conduct a delayed primary offering “off-the-shelf”.&nbsp; In the spirit of the legislation, the SEC may decide to expand Rule 251(d)(3) to permit shelf offerings to expand the utility of Regulation A and bring it into closer conformity with Rule 415.&nbsp; However, if the SEC elects to do so, it may impose restrictions on such offerings, including limitations on which issuers can use any shelf offering procedure and limitations on the amount that may be sold, similar to those contained in the “baby shelf” rule in General Instruction I.B.6. to Form S-3.</p><p><strong>Eligibility</strong></p><p>Regulation A is not available to certain issuers, such as companies organized outside the U.S. and Canada; shell companies; investment companies; issuers of interests in oil, gas and other mineral rights; issuers of asset-backed securities; issuers that have had their securities denied or suspended from registration by the SEC within the past five years; and issuers that are disqualified by any “bad actor” events involving the issuer or any of its affiliates. However, this expansion of Regulation A is likely to provide significant relief to qualifying smaller reporting companies.</p><p><em>The full text of S.2155, Economic Growth, Regulatory Relief, and Consumer Protection Act is available<span>&nbsp;</span><a rel='noopener noreferrer' href='https://www.congress.gov/bill/115th-congress/senate-bill/2155' target='_blank'>here</a>.</em></p>";
        ////        StringBuilder sb = new StringBuilder();
        ////        sb.Append("<style>p{font-size:10px;color:#0000FF;}</style><p><strong>What You Need To Know:</strong></p><img src='/1.jpg' /><ul><li>Regulation A is being made available to all reporting companies.</li><li>The change will likely have the greatest benefit for smaller reporting companies.</li><li>The availability of Regulation A will make it easier for smaller reporting companies to raise capital as compared to current options.</li></ul><p>&nbsp;</p><p>On May 24, 2018, the Economic Growth, Regulatory Relief, and Consumer Protection Act was signed into law. While press coverage of the Act mostly focused on its rollback of regulations applicable to financial institutions and originating in the Dodd-Frank Wall Street Reform and Consumer Protection Act of 2010, significantly, the new Act also requires the U.S. Securities and Exchange Commission (SEC) to amend its rules to permit reporting companies to use Regulation A.</p><p>Regulation A provides an exemption from the registration provisions of the Securities Act of 1933, as amended (Securities Act), by permitting offerings of up to $20 million in any one-year period (Tier 1 Offerings) and offerings of up to $50 million in any one-year period (Tier 2 Offerings) subject to compliance with certain requirements. Until now, Regulation A has only been available to U.S. and Canadian issuers that were not subject to the reporting requirements of the Securities Exchange Act of 1934, as amended (Exchange Act). However, the new law orders the SEC to remove this eligibility requirement, making Regulation A available to all reporting companies, and mandates that the ongoing reporting obligations associated with Tier 2 Offerings are satisfied by Exchange Act reporting (which a public company already does).</p><p><span class='arial_12'><strong>What This May Mean for Smaller Public Companies</strong></span></p><p>There are three significant advantages that this expansion of Regulation A is expected to have for smaller companies that are already public.</p><p>First, reporting companies that do not trade on national securities exchanges (for example, those that trade in the over-the-counter markets) will be able to avoid state securities law requirements by conducting future offerings in compliance with Tier 2 of Regulation A.</p><p>Second, Regulation A permits issuers to do significant investor outreach prior to submitting an offering statement to the SEC, including solicitations of written indications of interest. That outreach will enable smaller reporting companies to gauge investor interest in their securities by contacting retail as well as institutional investors before committing to the expense of preparing an offering circular.</p><p>Third, Regulation A will allow smaller public companies to make offerings to retail investors through a general solicitation without having to comply with the burdensome income verification requirements of Rule 506(c) under Regulation D.</p><p><strong>Offerings Off-the-Shelf</strong></p><p>Rule 251(d)(3) of Regulation A permits certain offerings to be made on a delayed or continuous basis pursuant to a qualified offering statement.&nbsp; However, as currently written, Rule 251(d)(3) would not permit an issuer to conduct a delayed primary offering “off-the-shelf”.&nbsp; In the spirit of the legislation, the SEC may decide to expand Rule 251(d)(3) to permit shelf offerings to expand the utility of Regulation A and bring it into closer conformity with Rule 415.&nbsp; However, if the SEC elects to do so, it may impose restrictions on such offerings, including limitations on which issuers can use any shelf offering procedure and limitations on the amount that may be sold, similar to those contained in the “baby shelf” rule in General Instruction I.B.6. to Form S-3.</p><p><strong>Eligibility</strong></p><p>Regulation A is not available to certain issuers, such as companies organized outside the U.S. and Canada; shell companies; investment companies; issuers of interests in oil, gas and other mineral rights; issuers of asset-backed securities; issuers that have had their securities denied or suspended from registration by the SEC within the past five years; and issuers that are disqualified by any “bad actor” events involving the issuer or any of its affiliates. However, this expansion of Regulation A is likely to provide significant relief to qualifying smaller reporting companies.</p><p><em>The full text of S.2155, Economic Growth, Regulatory Relief, and Consumer Protection Act is available<span>&nbsp;</span><a rel='noopener noreferrer' href='https://www.congress.gov/bill/115th-congress/senate-bill/2155' target='_blank'>here</a>.</em></p>");

        ////        // sb.Append("<div class='row'><div class='column' style='background-color:#aaa;'><h2>Column 1</h2><p>Some text..</p></div><div class='column' style='background-color:#bbb;'><h2>Column 2</h2><p>Some text..</p></div></div>");
        ////        StringReader sr1 = new StringReader(sb.ToString());
        ////        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr1);

        ////        HTMLWorker htmlparser = new HTMLWorker(doc);

        ////        //htmlparser.Parse(sr);

        ////        ct.SetSimpleColumn(10, 160, 175, 0, 15, Element.ALIGN_LEFT);
        ////        string sr2 = sr1.ToString();
        ////        ct.AddText(new Phrase(sr2));
        ////        ct.AddText(new Phrase(sr2));
        ////        ct.AddText(new Phrase(sr2));

        ////        //ct.SetColumns(36f, doc.PageSize.Width - 36f, 24f, 2);

        ////        var elements = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(sb.ToString(), null);



        ////        //foreach (var es in elements)
        ////        //{
        ////        //    if (es.Chunks.Count > 0)
        ////        //    {


        ////        //        for (int k = 0; k < es.Chunks.Count; k++)
        ////        //        {
        ////        //            string str = es.Chunks[k].Content.ToString();
        ////        //            // es.Chunks[k].Content
        ////        //            StringReader sr = new StringReader(str);
        ////        //            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

        ////        //            ct.SetSimpleColumn(80, 460, 475, 0, 15, Element.ALIGN_LEFT);
        ////        //            ct.AddText(new Phrase(str));


        ////        //            //var paragraph = new Paragraph();
        ////        //            //ct.SetSimpleColumn(paragraph, 80, 460, 475, 0, 15, Element.ALIGN_LEFT);
        ////        //            //paragraph.Add(str);
        ////        //            //ct.AddText(paragraph);

        ////        //        }

        ////        //    }

        ////        //}








        ////        //ct.(sr);

        ////        //var elements = iTextSharp.tool.xml.XMLWorkerHelper.ParseToElementList(sr, null);

        ////        ////List list = new List(List.UNORDERED);
        ////        //List<string> list = new List<string>();

        ////        //Paragraph paragraph1 = new Paragraph();
        ////        //RomanList romanlist = new RomanList(true, 20);
        ////        //foreach (var es in elements)
        ////        //{

        ////        //    if(es.Type == 14)
        ////        //    {


        ////        //      for(int k=0;k<es.Chunks.Count;k++)
        ////        //      {
        ////        //            string str = es.Chunks[k].Content.ToString();
        ////        //            // es.Chunks[k].Content

        ////        //            list.Add(str);
        ////        //            //romanlist.Add(es.Chunks[k]);
        ////        //        }


        ////        //        for (int m = 0; m < list.Count; m++)
        ////        //        {
        ////        //            ct.AddText(new Phrase(string.Concat("     ", (m + 1), ".  ")));
        ////        //            ct.AddText(new Phrase(list[m]));
        ////        //            if (m != list.Count - 1)
        ////        //              ct.AddText(Chunk.NEWLINE);


        ////        //        }


        ////        //        // doc.Add(list);
        ////        //        //paragraph.Add(list);

        ////        //        //ct.AddElement(list);


        ////        //    }
        ////        //    else
        ////        //    {
        ////        //        //StringReader sr = new StringReader(es.ToString());
        ////        //        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);

        ////        //        var paragraph = new Paragraph();
        ////        //        ct.SetSimpleColumn(paragraph, 80, 460, 475, 0, 15, Element.ALIGN_LEFT);
        ////        //        paragraph.Add(es);
        ////        //        ct.AddText(paragraph);
        ////        //        paragraph.Add(Chunk.NEWLINE);
        ////        //    }









        ////        //}







        ////        //ct.AddElement(paragraph);


        ////        //doc.Add(list);



        ////        //Paragraph par = new Paragraph();
        ////        //List<IElement> elements = HTMLWorker.ParseToList(new StringReader((htmlText)), null);
        ////        //foreach (IElement element in elements)
        ////        //{

        ////        //    par.Add(element);
        ////        //}
        ////        //ct.AddText(par);






        ////        //HTMLWorker hw = new HTMLWorker(doc);
        ////        //StringReader sr = new StringReader(htmlText);
        ////        //iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);



        ////        //ct.SetSimpleColumn(pos[0].position.Left, pos[0].position.Bottom, pos[0].position.Right, pos[0].position.Top);
        ////        //very important!!!

        ////        //ct.AddText(new Phrase("<p><strong>What You Need To Know:</strong></p><ul><li>Regulation A is being made available to all reporting companies.</li><li>The change will likely have the greatest benefit for smaller reporting companies.</li><li>The availability of Regulation A will make it easier for smaller reporting companies to raise capital as compared to current options.</li></ul><p>&nbsp;</p><p>On May 24, 2018, the Economic Growth, Regulatory Relief, and Consumer Protection Act was signed into law. While press coverage of the Act mostly focused on its rollback of regulations applicable to financial institutions and originating in the Dodd-Frank Wall Street Reform and Consumer Protection Act of 2010, significantly, the new Act also requires the U.S. Securities and Exchange Commission (SEC) to amend its rules to permit reporting companies to use Regulation A.</p><p>Regulation A provides an exemption from the registration provisions of the Securities Act of 1933, as amended (Securities Act), by permitting offerings of up to $20 million in any one-year period (Tier 1 Offerings) and offerings of up to $50 million in any one-year period (Tier 2 Offerings) subject to compliance with certain requirements. Until now, Regulation A has only been available to U.S. and Canadian issuers that were not subject to the reporting requirements of the Securities Exchange Act of 1934, as amended (Exchange Act). However, the new law orders the SEC to remove this eligibility requirement, making Regulation A available to all reporting companies, and mandates that the ongoing reporting obligations associated with Tier 2 Offerings are satisfied by Exchange Act reporting (which a public company already does).</p><p><span class='arial_12'><strong>What This May Mean for Smaller Public Companies</strong></span></p><p>There are three significant advantages that this expansion of Regulation A is expected to have for smaller companies that are already public.</p><p>First, reporting companies that do not trade on national securities exchanges (for example, those that trade in the over-the-counter markets) will be able to avoid state securities law requirements by conducting future offerings in compliance with Tier 2 of Regulation A.</p><p>Second, Regulation A permits issuers to do significant investor outreach prior to submitting an offering statement to the SEC, including solicitations of written indications of interest. That outreach will enable smaller reporting companies to gauge investor interest in their securities by contacting retail as well as institutional investors before committing to the expense of preparing an offering circular.</p><p>Third, Regulation A will allow smaller public companies to make offerings to retail investors through a general solicitation without having to comply with the burdensome income verification requirements of Rule 506(c) under Regulation D.</p><p><strong>Offerings Off-the-Shelf</strong></p><p>Rule 251(d)(3) of Regulation A permits certain offerings to be made on a delayed or continuous basis pursuant to a qualified offering statement.&nbsp; However, as currently written, Rule 251(d)(3) would not permit an issuer to conduct a delayed primary offering “off-the-shelf”.&nbsp; In the spirit of the legislation, the SEC may decide to expand Rule 251(d)(3) to permit shelf offerings to expand the utility of Regulation A and bring it into closer conformity with Rule 415.&nbsp; However, if the SEC elects to do so, it may impose restrictions on such offerings, including limitations on which issuers can use any shelf offering procedure and limitations on the amount that may be sold, similar to those contained in the “baby shelf” rule in General Instruction I.B.6. to Form S-3.</p><p><strong>Eligibility</strong></p><p>Regulation A is not available to certain issuers, such as companies organized outside the U.S. and Canada; shell companies; investment companies; issuers of interests in oil, gas and other mineral rights; issuers of asset-backed securities; issuers that have had their securities denied or suspended from registration by the SEC within the past five years; and issuers that are disqualified by any “bad actor” events involving the issuer or any of its affiliates. However, this expansion of Regulation A is likely to provide significant relief to qualifying smaller reporting companies.</p><p><em>The full text of S.2155, Economic Growth, Regulatory Relief, and Consumer Protection Act is available<span>&nbsp;</span><a rel='noopener noreferrer' href='https://www.congress.gov/bill/115th-congress/senate-bill/2155' target='_blank'>here</a>.</em></p>", font2));

        ////        //ct.AddText(new Phrase("Vivamusenim nisi, mollis in, sodalesvel, convallis a, augue? Proin non enim.Nullamelementumeuismoderat.Aliquammalesuadaeleifend quam! Nullafacilisi.Aeneanutturpis ac esttempormalesuada. Maecenas scelerisqueorci sit ametauguelaoreet tempus. Duisinterdumestuteros. Fusce dictum dignissimelit.Morbi at dolor.Fusce magna.Nullatellusturpis, mattisut, eleifend a, adipiscing vitae, mauris.Pellentesquemattislobortis mi.\n\n", font2));

        ////        //ct.AddText(new Phrase("Nullam sit ametmetusscelerisquediamhendreritporttitor. Aeneanpellentesque, lorem a consectetuerconsectetuer, nuncmetushendrerit quam, mattisultricesloremtelluslaciniamassa. Aliquam sit ametodio. Proinmauris.Integer dictum quam a quam accumsanlacinia.Pellentesquepulvinarfeugiateros.Suspendisserhoncus.Sedconsectetuerleoeu nisi. Suspendissemassa! Sedsuscipit lacus sit ametelit! Aliquamsollicitudincondimentumturpis.Nuncutaugue! Maecenas eueros.Morbi in urnaconsectetueripsumvehiculatristique.\n\n", font2));

        ////        //ct.AddText(new Phrase("Donecimperdietpurusvel ligula. Vestibulumtempor, odioutscelerisqueeleifend, nullasapienlaoreet dui; velaliquamarculiberoeu ante.Curabiturrutrumtristique mi. Sedlobortisiaculisarcu.Suspendissemauris.Aliquammetus lacus, elementumquis, mollis non, consequatnec, tortor.\n", font2));

        ////        //ct.AddText(new Phrase("Quisque id diam. Utegestasleo a elit. Nulla in metus.Aliquamiaculisturpis non augue.Donec a nunc?Phaselluseueros.Nam luctus.Duiseu mi. Utmollis.Nullafacilisi.Loremipsumdolor sitamet, consectetueradipiscingelit. Class aptenttacitisociosquadlitoratorquent per conubia nostra, per inceptoshimenaeos.Aeneanpede.Nullafacilisi.Vestibulummattisadipiscingnulla.Praesentorci ante, mattis in, cursuseget, posueresed, mauris.\n\n", font2));

        ////        //ct.AddText(new Phrase("Nullafacilisi. Nuncaccumsanrisusaliquet quam. Nam pellentesque! Aeneanporttitor.Aeneancongueullamcorpervelit.Phasellussuscipitplacerattellus.Vivamusdiamodio, tempus quis, suscipit a, dictum eu; lectus.Sedvelnisl.Utinterdumurnaeunibh.Praesentvehicula, orci id venenatisultrices, maurisurnamollis lacus, etblanditodio magna at enim. Pellentesqueloremfelis, ultricesquis, gravidased, pharetra vitae, quam.Maurisliberoipsum, pharetra a, faucibusaliquet, pellentesque in, mauris.Cras magna neque, interdumvel, variusnec; vulputate at, erat. Quisque vitae urna.Suspendissepotenti.Nullaluctuspurus at turpis! Vestibulum vitae dui.Nullamodio.\n\n", font2));

        ////        //ct.AddText(new Phrase("Vestibulum ante ipsumprimis in faucibusorciluctus et ultricesposuerecubiliaCurae; Sedeget mi at semiaculishendrerit. Nullafacilisi.Etiamsedelit.In viverradapibussapien.Aliquam nisi justo, ornarenon, ultricies vitae, aliquam sit amet, risus! Cum sociisnatoquepenatibusetmagnis dis parturient montes, nasceturridiculus mus. Phasellusrisus. Vestibulumpretiumaugue non mi. Sed magna.In hachabitasseplateadictumst.Quisquemassa. Etiamviverradiampharetra ante.Phasellusfringillavelitutodio! Nam necnulla.\n\n", font2));

        ////        //ct.AddText(new Phrase("Integer augue. Morbiorci.Sedquisnibh.Nullam ac magna id leofaucibusornare. Vestibulumegetlectus sit ametnuncfacilisisbibendum. Donecadipiscingconvallis mi. Cumsociisnatoquepenatibus et magnis dis parturient montes, nasceturridiculus mus. Vivamusenim. Mauris ligula lorem, pellentesquequis, semper sed, tristique sit amet, justo.Suspendissepotenti.Proin vitae enim.Morbi et nisi sit ametsapienve.\n\n", font2));

        ////        float gutter = 15f;
        ////        float colwidth = (doc.Right - doc.Left - gutter) / 2;
        ////        float[] left = { doc.Left + 90f , doc.Top - 80f,
        ////doc.Left + 90f, doc.Top - 170f,
        ////doc.Left, doc.Top - 170f,
        ////doc.Left ,doc.Bottom };

        ////        float[] right = { doc.Left + colwidth, doc.Top - 80f,
        ////doc.Left + colwidth, doc.Bottom };

        ////        float[] left2 = { doc.Right - colwidth, doc.Top - 80f,
        ////doc.Right - colwidth, doc.Bottom };

        ////        float[] right2 = {doc.Right, doc.Top - 80f,
        ////doc.Right, doc.Bottom };

        ////        int status = 0;
        ////        int i = 0;
        ////        int j = 1;

        ////        //ct.YLine = doc.Top - 80f;
        ////        //Commit the content of the ColumnText to the document
        ////        //ColumnText.Go() returns NO_MORE_TEXT (1) and/or NO_MORE_COLUMN (2)
        ////        //In other words, it fills the column until it has either run out of column, or text, or both
        ////       // ct.Go();
        ////        //Checks the value of status to determine if there is more text
        ////        //If there is, status is 2, which is the value of NO_MORE_COLUMN
        ////        while (ColumnText.HasMoreText(status))
        ////        {
        ////            if (i == 0)
        ////            {
        ////                //Writing the first column
        ////                ct.SetColumns(left, right);
        ////                i++;
        ////            }
        ////            else
        ////            {
        ////                //write the second column
        ////                ct.SetColumns(left2, right2);

        ////            }
        ////            //Needs to be here to prevent app from hanging
        ////            ct.YLine = doc.Top - 80f;
        ////            //Commit the content of the ColumnText to the document
        ////            //ColumnText.Go() returns NO_MORE_TEXT (1) and/or NO_MORE_COLUMN (2)
        ////            //In other words, it fills the column until it has either run out of column, or text, or both
        ////            status = ct.Go();

        ////            if (j % 2 == 0)
        ////            {
        ////                doc.NewPage();
        ////                i = 0;
        ////            }

        ////            j++;



        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        //Log(ex.Message);
        ////    }
        ////    finally
        ////    {
        ////        doc.Close();
        ////    }

        ////    return View();
        ////}








        private string MoveCssInline(string htmlText)
        {
            throw new NotImplementedException();
        }
    }
}