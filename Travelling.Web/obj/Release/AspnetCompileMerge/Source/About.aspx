<%@ Page Title="About" Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Travelling.Web.About" %>

<html lang="en">
<head>
      <meta charset="utf-8">
      <title>Adminity - Tables</title>
      <link rel="shortcut icon" href="favicon.gif">
    
    <link rel="shortcut icon" href="/assets/img/favicon.gif">
    <!---CSS Files-->
    <link rel="stylesheet" href="/assets/css/master.css">
    <link rel="stylesheet" href="/assets/css/tables.css">
    <!---jQuery Files-->
    <script src="../assets/js/jquery-1.7.1.min.js"></script>
    <script src="../assets/js/jquery-ui-1.8.17.min.js"></script>
    <script src="../assets/js/styler.js"></script>
    <script src="../assets/js/jquery.tipTip.js"></script>
    <script src="../assets/js/colorpicker.js"></script>
    <script src="../assets/js/sticky.full.js"></script>
    <script src="../assets/js/global.js"></script>
    <script src="../assets/js/jquery.dataTables.min.js"></script>
    <!---Fonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700' rel='stylesheet' type='text/css'>
</head>
<body>


    <!--- HEADER -->

	<div class="header">
   <a href="dashboard.html"><img src="assets/img/logo.png" alt="Logo" /></a> 
   <div class="styler">
     <ul class="styler-show">
       <li><div id="colorSelector-top-bar"></div></li>
       <li><div id="colorSelector-box-head"></div></li>
     </ul>
   </div>
  </div>

  <div class="top-bar">
      <ul id="nav">
        <li id="user-panel">
          <img src="assets/img/usr-avatar.jpg" id="usr-avatar" alt="" />
          <div id="usr-info">
            <p id="usr-name">Welcome back, Michael.</p>
            <p id="usr-notif">You have 6 notifications. <a href="#">View</a></p>
            <p><a href="#">Preferences</a><a href="#">Profile</a><a href="index.html">Log out</a></p>
          </div>
        </li>
        <li>
        <ul id="top-nav">
         <li class="nav-item">
           <a href="dashboard.html"><img src="assets/img/dash.png" alt="" /><p>Dashboard</p></a>
         </li>
         <li class="nav-item">
           <a href="analytics.html"><img src="assets/img/anlt.png" alt="" /><p>Analytics</p></a>
         </li>
         <li class="nav-item">
           <a href="#"><img src="assets/img/tb-active.png" alt="" /><p>Tables</p></a>
         </li>
         <li class="nav-item">
           <a href="calendar.html"><img src="assets/img/cal.png" alt="" /><p>Calendar</p></a>
         </li>
         <li class="nav-item">
           <a href="widgets.html"><img src="assets/img/widgets.png" alt="" /><p>Widgets</p></a>
         </li>
         <li class="nav-item">
           <a href="grid.html"><img src="assets/img/grid.png" alt="" /><p>Grid</p></a>
           <ul class="sub-nav">
            <li><a href="#">12 Columns</a></li>
            <li><a href="#">16 Columns</a></li>
          </ul>
         </li>
         <li class="nav-item">
           <a href="filemanager.html"><img src="assets/img/flm.png" alt="" /><p>File Manager</p></a>
         </li>
         <li class="nav-item">
           <a href="gallery.html"><img src="assets/img/gal.png" alt="" /><p>Gallery</p></a>
         </li>
         <li class="nav-item">
           <a href="icons.html"><img src="assets/img/icn.png" alt="" /><p>Icons</p></a>
         </li>
         <li class="nav-item">
           <a href="#"><img src="assets/img/err.png" alt="" /><p>Error Pages</p></a>
           <ul class="sub-nav">
            <li><a href="403.html">403 Page</a></li>
            <li><a href="404.html">404 Page</a></li>
            <li><a href="503.html">503 Page</a></li>
          </ul>
         </li>
         <li class="nav-item">
           <a href="typography.html"><img src="assets/img/typ.png" alt="" /><p>Typography</p></a>
         </li>
       </ul>
      </li>
     </ul>
  </div>




</body>
</html>

