/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: customer@thefraudexplorer.com
 * Licensed under GNU GPLv3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-05-31 15:12:41 -0500 (Wed, 31 May 2016)
 * Revision: v0.9.5-beta
 *
 * Description: Code for AJAX
 */

$(document).ready(function() 
{
    $('.tooltip').tooltipster();
});

/* Ajax for reset XML file */

$(function() 
{
    $('a[class="reset-xml-button"]').click(function()
    {  
        $.ajax({
            url: "eraseCommands.php",
            type: "POST",
            data: "",	
            success: function(){},
            error:function(){}   
        });
    });
});

/* Code for refresh main Table using AJAX */

$.ajaxSetup ({
    cache: true
});

$(document).ready(function()
{
    refreshTable();
});

function refreshTable()
{
    $('#tableHolder').load('getTableX.php', function()
    {
       /* setTimeout(refreshTable, 60000); */
    });
}

/* Code for refresh XML Table using AJAX */

$(document).ready(function()
{
    refreshXML();
});

function refreshXML()
{
    $('#tableHolderXML').load('getXMLfile.php', function()
    {
        setTimeout(refreshXML, 2000);
    });
}

/* Code for html footer include */

$(function()
{
    $("#includedFooterContent").load("mainFooter.html"); 
});
