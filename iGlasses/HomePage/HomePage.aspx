<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage_HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="home-page.js"></script>
  <link rel="stylesheet" href="homepage.css">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
      <li data-target="#myCarousel" data-slide-to="3"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img draggable="false" src="../Images/1.jpg" class="center-block">
        <div class="carousel-caption d-none d-md-block" style="color:black"> 
          <h3>Putting on a new pair of glasses or sunglasses is a simple way to completely transform your look - just
            like a new hairstyle.</h3>
        </div>
      </div>

      <div class="item">
        <img draggable="false" src="../Images/2.jpg" class="center-block">
        <div class="carousel-caption d-none d-md-block" style="color:black">
          <h3>Don't call the world dirty because you forgot to clean your glasses</h3>
        </div>
      </div>

      <div class="item">
        <img draggable="false" src="../Images/lenses.jpg" class="center-block">
        <div class="carousel-caption d-none d-md-block" style="color:black">
          <h3>Competence, like truth, beauty, and contact lenses, is in the eye of the beholder.</h3>
        </div>
      </div>
      <div class="item">
        <img draggable="false" src="../Images/4.jpg" class="center-block">
        <div class="carousel-caption d-none d-md-block" style="color:black">
          <h3>I am more than what you see</h3>
        </div>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div></asp:Content>