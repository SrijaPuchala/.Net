<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master"  AutoEventWireup="true" CodeFile="selectimg1.aspx.cs" Inherits="selectimg1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
			
			<div class="panes">
                
			    <asp:ImageMap ID="ImageMap1" runat="server" Height="380px" 
                    HotSpotMode="PostBack" ImageUrl="~/Images/baby1.jpg" Width="510px" 
                    onclick="ImageMap1_Click">
                    <asp:CircleHotSpot AlternateText="lefteye" PostBackValue="lefteye" Radius="40" 
                        X="162" Y="122" HotSpotMode="PostBack" NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="righteye" HotSpotMode="PostBack" 
                        PostBackValue="righteye" Radius="30" X="330" Y="126" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="forehead" HotSpotMode="PostBack" 
                        PostBackValue="forehead" Radius="60" X="211" Y="57" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="nose" HotSpotMode="PostBack" 
                        PostBackValue="nose" Radius="60" X="210" Y="180" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="toungh" PostBackValue="toungh" Radius="45" 
                        X="232" Y="320" NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="lips" HotSpotMode="PostBack" 
                        PostBackValue="lips" Radius="30" X="235" Y="262" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="rightcheek" HotSpotMode="PostBack" 
                        PostBackValue="rightcheek" Radius="75" X="395" Y="225" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="leftcheek" HotSpotMode="PostBack" 
                        PostBackValue="leftcheek" Radius="75" X="91" Y="236" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="leftear" HotSpotMode="PostBack" 
                        PostBackValue="leftear" Radius="40" X="476" Y="208" 
                        NavigateUrl="~/selectimage2.aspx" />
                    <asp:CircleHotSpot AlternateText="rightear" HotSpotMode="PostBack" 
                        PostBackValue="rightear" Radius="30" X="33" Y="180" 
                        NavigateUrl="~/selectimage2.aspx" />
                </asp:ImageMap>
                
			    <br />
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                
			    <br />
                <br />
                <asp:Label ID="Label2" runat="server"></asp:Label>
                
			</div>
	
		<div class="clear"></div>
	
    </asp:Content>
