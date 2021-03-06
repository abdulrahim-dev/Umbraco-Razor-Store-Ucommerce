<%@ Import Namespace="UCommerce.Presentation.Web" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditEmailProfileBaseProperties.ascx.cs" Inherits="UCommerce.Web.UI.Settings.Email.EditEmailProfileBaseProperties" %>
<%@ Register tagPrefix="commerce" tagName="ValidationSummary" src="../../Controls/ValidationSummaryDisplay.ascx" %>

<commerce:validationsummary runat="server" />
<div class="propertyPane">

    <div class="propertyItem">
        <div class="propertyItemHeader"><asp:Localize runat="server" meta:resourceKey="ModifiedOn" /></div>
        <div class="propertyItemContent">
            <asp:Label runat="server" Text="<%# View.IsNew ? String.Empty : View.EmailProfile.ModifiedOn.ToString() %>" />
        </div>
    </div>
    <div class="propertyItem">
        <div class="propertyItemHeader"><asp:Localize runat="server" meta:resourceKey="ModifiedBy" /></div>
        <div class="propertyItemContent">
            <asp:Label runat="server" Text="<%# View.EmailProfile.ModifiedBy %>" />
        </div>
    </div>
    <div class="propertyPaneFooter">-</div>
</div>
