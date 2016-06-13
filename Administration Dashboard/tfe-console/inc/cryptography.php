<?php

/*
 * The Fraud Explorer
 * http://www.thefraudexplorer.com/
 *
 * Copyright (c) 2016 The Fraud Explorer
 * email: customer@thefraudexplorer.com
 * Licensed under GNU GPL v3
 * http://www.thefraudexplorer.com/License
 *
 * Date: 2016-06-31 15:12:41 -0500 (Wed, 31 Jun 2016)
 * Revision: v0.9.6-beta
 *
 * Description: Code for cryptography
 */

function SQLInjectionPrevention($variable)
{
 return addcslashes(mysql_real_escape_string($variable),',<>');
}

function encRijndael($unencrypted)
{
 $result_key=mysql_query("SELECT * FROM t_crypt");
 $row_key = mysql_fetch_array($result_key);
 $key = $row_key[0];
 $iv = $row_key[1];
 $iv_utf = mb_convert_encoding($iv, 'UTF-8');
 $toreturn = mcrypt_encrypt(MCRYPT_RIJNDAEL_128, $key, $unencrypted, MCRYPT_MODE_CBC, $iv_utf);
 $toreturn = base64_encode($toreturn);
 return $toreturn;
}

function decRijndael($encrypted)
{
 $result_key=mysql_query("SELECT * FROM t_crypt");
 $row_key = mysql_fetch_array($result_key);
 $key = $row_key[0];
 $iv = $row_key[1];
 $iv_utf = mb_convert_encoding($iv, 'UTF-8');
 $toreturn = mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode(str_replace("_","/",str_replace("-","+",$encrypted))), MCRYPT_MODE_CBC, $iv_utf);
 $toreturn = filter_var($toreturn, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW);
 return $toreturn;
}

function decRijndaelBLOB($encrypted)
{
 $encrypted = SQLInjectionPrevention($encrypted);
 $result_key=mysql_query("SELECT * FROM t_crypt");
 $row_key = mysql_fetch_array($result_key);
 $key = $row_key[0];
 $iv = $row_key[1];
 $iv_utf = mb_convert_encoding($iv, 'UTF-8');
 $toreturn = mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode(str_replace("_","/",str_replace("-","+",$encrypted))), MCRYPT_MODE_CBC, $iv_utf);
 return SQLInjectionPrevention(base64_decode($toreturn));
}

function decRijndaelFILE($encrypted)
{
 $encrypted = SQLInjectionPrevention($encrypted);
 $result_key=mysql_query("SELECT * FROM t_crypt");
 $row_key = mysql_fetch_array($result_key);
 $key = $row_key[0];
 $iv = $row_key[1];
 $iv_utf = mb_convert_encoding($iv, 'UTF-8');
 $toreturn = mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode(str_replace("_","/",str_replace("-","+",$encrypted))), MCRYPT_MODE_CBC, $iv_utf);
 return base64_decode($toreturn);
}

function decRijndaelWOSC($encrypted)
{
 $result_key=mysql_query("SELECT * FROM t_crypt");
 $row_key = mysql_fetch_array($result_key);
 $key = $row_key[0];
 $iv = $row_key[1];
 $iv_utf = mb_convert_encoding($iv, 'UTF-8');
 $toreturn = mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $key, base64_decode($encrypted), MCRYPT_MODE_CBC, $iv_utf);
 $toreturn = filter_var($toreturn, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW);
 return $toreturn;
}

function str_rot($s, $n = -7)
{
        static $letters = 'AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz';
        $n = (int)$n % 26;
        if (!$n) return $s;
        if ($n < 0) $n += 26;
        if ($n == 13) return str_rot13($s);
        $rep = substr($letters, $n * 2) . substr($letters, 0, $n * 2);
        return strtr($s, $letters, $rep);
}

?>
