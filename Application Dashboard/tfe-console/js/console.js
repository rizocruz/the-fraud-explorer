/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: customer@thefraudexplorer.com
 * Licensed under GNU GPLv3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-07
 * Revision: v0.9.7-beta
 *
 * Description: Code for AJAX
 */

function iSubmitEnter(oEvent, oForm)
{ 
    var iAscii; 		 
    if (oEvent.keyCode) iAscii = oEvent.keyCode; 
    else if (oEvent.which) iAscii = oEvent.which; 
    else return false; 
    if (iAscii == 13) oForm.submit(); 
    return true; 
} 

/* Ajax for show under command line the result of the command execution */

$(document).ready(function() 
{	
    $().ajaxStart(function() 
    {
        $('#loading').show();
        $('#result').hide();
    }).ajaxStop(function() 
    {
        $('#loading').hide();
        $('#result').fadeIn('slow');
    });
    $('#form, #fat, #fo3').submit(function() 
    {
        $.ajax({
            type: 'POST',
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function(data) 
            {
                //$('#result').html(data);
            }
        })
        var command = document.getElementById("commands").value;
        command = command.replace(" ","");
        if(command.substring(0,5)=="reset")
        {
            location.href="mainMenu";
        }
        if(command.substring(0,5)=="clear")
        {
            $.ajax(
            {
                url: "eraseCommands.php",
                type: "POST",
                data: ""
            });  
        }
        document.getElementById("commands").value='';
        return false;
    }); 
})  

/* Ajax for show the status of command execution */

function getURLParameter(name)
{
    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search)||[,""])[1].replace(/\+/g, '%20'))||null
}

$(document).ready(function()
{
    refreshCommandStatus();
});

function refreshCommandStatus()
{
    myvar = getURLParameter('agent');
    $('#commandStatus').load('statusCommand.php?agent='+myvar, function()
    {
        setTimeout(refreshCommandStatus, 1000);
    });
}
