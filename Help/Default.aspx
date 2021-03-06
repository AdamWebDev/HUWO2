﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HNHUWO2.Help.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Help</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Help</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">
    <div class="help">
    <h3>How to complete a Work Order for Communications Services</h3>
    <p>Communications Services has developed a simplified and easy-to-use work order system to fill out and submit when a print, radio or web project need to be created. Similar to the I.S. help desk, any work that needs to be done with Communications Services requires a work order. Whatever the project may be, Communications Services needs to at least be made aware of it even if you believe the work might be contracted out. Please use Communications Services as your contact for all web related content before contacting the IS help desk.</p>
    <p>When you launch the work order system, you will be able to view any of your existing work orders and their status (e.g. pending approval of your program manager, approved, in production, completed, etc.) or submit a new work order.</p>
    
    <ul>
        <li><a href="#create">Create a New Work Order</a></li>
        <ul>
            <li><a href="#print">Print Work Order</a></li>
            <li><a href="#video">Video Work Order</a></li>
            <li><a href="#web">Web Work Order</a></li>
            <li><a href="#radio">Radio Ad</a></li>
            <li><a href="#news">Media Release</a></li>
            <li><a href="#quote">Request a Quote</a></li>
        </ul>
        <li><a href="#submit">Submitting a Work Order</a></li>
        <li><a href="#approve">Approval Process</a></li>
        <li><a href="#troubleshoot">Troubleshooting</a></li>
        <li><a href="#managers">For Program Managers</a></li>
        <ul>
            <li><a href="#staff">View My Staff’s Work Orders</a></li>
            <li><a href="#pending">All Pending Work Orders</a></li>
            <li><a href="#reports">Reports</a></li>
        </ul>
    </ul>

    <h4 id="create">Create a New Work Order...</h4>
    <p>By selecting the icon to “Create a New Work Order” you will have the option to create a print, web or video project, place a radio ad, submit a media release, or request a quote for a commercial order.</p>
    
    <h5 id="print">Print Work Order...</h5>
    <p>All types of print jobs that need to be created or designed by Communications Services (including promotional items) would be requested using this form.</p>
    <uc:Notification ID="notQuote" runat="server" Type="Attention" Message="Please note: You DO NOT need to submit a “Request quote for a commercial order” form in addition to filling out a print work order if the project is going to be commercially printed." />
    <p>There is also an option to “add to website” on the Print Work Order. If you select “Yes” you will be prompted to fill out fields relating to the web. Please use print work order forms if you are making changes to printed material and use this option if it is found on the website as well.</p>
    <p>If you have hard copies that you need to provide to Communications Services, simply add that detail to the “Notes” section of the work order. At the bottom of the form is where you select and upload any attachments that apply to the project. Multiple files can be uploaded at the same time, including images or text files.</p>
    
    <h5 id="video">Video Work Order…</h5>
    <p>This work order is filled out if you are looking to create or modify any type of video project whether it is for an online application like YouTube, Facebook etc., for internal use or DVD distribution. At the bottom of the form, please include any notes or attachments (if necessary) with all of the information needed for your video request.</p>

    <h5 id="web">Web Work Order...</h5>
    <p>Please select the web work order form if the content is found online only and a printed version does not exist. The first dropdown menu in the web work order will ask for the type of web work you are requesting to be completed. Please do not contact the IS help desk for any web related requests.</p>
    <ul>
        <li>New Content: Any information you want added to any section of any of the websites belonging to the health unit.</li>
        <li>Update Content: Any information you are replacing, adding to or deleting from that is currently on any of the health unit’s websites. You will be asked to provide the exact URL of the existing content. You can provide this by visiting the site, finding the page you are asking Communications Services to work on, and copying the URL from your browser and pasting it into the appropriate field on the work order form.</li>
        <li>New website: Any information that needs to be in its own stand-alone site. A meeting will need to be arranged to discuss the details, but this is the first step.</li>
        <li>CD 98.9 Web Ad: Box ads are placed on the radio stations website on a regular basis. These ads link directly to the related topic content on any of our health unit websites.</li>
        <li>Facebook Status Update: Any information you would like posted to the Health Unit’s Facebook account.</li>
    </ul>
    <p>Please include any notes or attachments (if necessary) with all of the information needed for your web request.</p>

    <h5 id="radio">Radio Ad Work Order...</h5>
    <p>When filling out the radio work order, attach a draft version of your ad(s), or the audio file of your ad(s) if available to the work order. Upon submission of the work order, a member of Communications Services will format and edit your radio ad(s) as needed, and return the revised ad(s) to you and your Program Manager for final approval. Once approved, the final ad(s) will be sent to the radio station.</p>

    <h5 id="news">Media Release Work Order...</h5>
    <p>When filling out the media release work order, attach a draft version of your media release to the work order. Upon submission of the work order, a member of Communications Services will format and edit your media release as needed, and return the revised media release to you and your Program Manager for final approval. Once approved, the final media release will be sent to the media.</p>

    <h5 id="quote">Request a quote for a commercial order...</h5>
    <p>This work order is only filled out when you have a potential commercial or outsourced order. This would only be requested if you are not ready to submit and start a project with Communications Services, and simply want to know if you have the budget necessary, or want more details on what is available from commercial printers. You will still need to fill out a “Print Work Order” after the quotes have been obtained so that Communications Services has all the details required to complete the project.</p>

    <h4 id="submit">Submitting a Work Order...</h4>
    <p>Make sure to review your work order carefully before you submit to ensure that all the information you have inputted is accurate. Once you have finalized your work order by clicking “submit”, you will be taken to the last tab that shows the details of the work order you have just submitted. No changes can be made to the work order once you have submitted it. Please note, it is everyone’s responsibility to write according to the Health Unit and Canadian Press standards and there are examples on SharePoint (<a href="http://net3/hss/hnhu/Communications/Forms/AllItems.aspx" target="_blank">http://net3/hss/hnhu/Communications/Forms/AllItems.aspx</a>) to help staff to do so. It is not solely on Communications Services to write or edit content including media releases and radio ads. Please make sure to review all proofs carefully. Most projects should not require more than 2 or 3 proofs and this can be accomplished by editing your projects thoroughly before submitting to Communications Services and reviewing the PDF’s in detail before signing off. Make sure you have also reviewed the minimum timelines document to allow everyone a fair chance to be in the queue and get their work done when required.</p>

    <h4 id="approve">Approval Process...</h4>
    <p>When you have submitted any one of the work orders, an email notification is sent to your Program Manager for approval. The email will include a link to the work order, and the Program Manager will have the option to approve it. If there are any problems with the work order, a new work order will need to be submitted, and the original work order deleted. Once your Program Manager has approved a work order, Communications Services is notified by email that a new work order exists. Please note, if your program Manager is away, ANY program Manager can go into the system and approve a work order.  A new form does not need to be submitted under their name.</p>

    <p>Communications Services will then go into the work order log information and change the status once they are ready to begin working on a project. This will be reflected in the status that you see when you “View Your Work Orders” that you have submitted.</p>

    <h4 id="troubleshoot">Troubleshooting....</h4>
    <p>If you require any assistance filling out a form, please contact <a href="mailto:communications@hnhu.org">communications@hnhu.org</a> and Communications Services would be happy to assist you. Please do not contact the I.S. Help Desk directly regarding any issues with the work order system as Communications Services has been asked to filter this information to them.</p>

    <h3 id="managers">For Program Managers</h3>
    <h4 id="staff">View My Staff's Work Orders...</h4>
    <p>This will show all of the work orders associated with you. By default, it will show you all of the unapproved work orders, but using the dropdown in the top right, you can see all other work orders in various states of completion.</p>

    <h4 id="pending">All Pending Work Orders</h4>
    <p>In the case that a program manager is absent, all program coordinators have access to approve any unapproved work orders.</p>

    <h4 id="reports">Reports...</h4>
    <p>As a Program Manager there is an option to create simple reports on the work orders that have been submitted. As an example, if a Program Manager wanted to know a total of projects, and a breakdown of what types were submitted in a given month, after inputting the information into the required fields, a simple report would be generated based on that information. </p>
    </div>
</asp:Content>
