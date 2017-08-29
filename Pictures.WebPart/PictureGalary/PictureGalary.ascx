<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PictureGalary.ascx.cs" Inherits="Pictures.WebPart.PictureGalary.PictureGalary" %>

<script type="text/javascript" src="../15/Pictures.WebPart/Scripts/jquery-3.1.1.min.js"></script>
<script type="text/javascript" src="../15/Pictures.WebPart/Scripts/pako.min.js"></script>
<script type="text/javascript" src="../15/Pictures.WebPart/Scripts/pictures.js"></script>

<asp:Label runat="server" ID="label"></asp:Label>
<asp:Repeater ID="picturesGalary" runat="server">
    <ItemTemplate>
        <li class="image-box">            
            <img id="image-<%# Eval("Id") %>" class="image-source" src="" data-imageSource="<%# Eval("Image") %>" alt="loading... <%# Eval("Title") %>"/>
            <div class="image-title"><%# Eval("Title") %></div>
        </li>
    </ItemTemplate>
</asp:Repeater>
