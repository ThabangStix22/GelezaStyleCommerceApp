<%@ Title="Login" Async="True" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GelezaStyleWebApp.Login" %>

<!DOCTYPE html>


<html>
  <head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>GelezaStyle | Log in </title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
</head>
   <body class="login-page" style="min-height: 466px;">
    <div class="login-box">
  <!-- /.login-logo -->
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <a href="Login.aspx" class="h1"><b>Geleza</b>Style</a>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Sign in to start your session</p>

      <form runat="server">
        <div class="input-group mb-3">
          <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="Email" required>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <input id="txtPassword" runat="server" type="password" class="form-control" placeholder="Password" required>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
     
        </div>
      
        <div class="social-auth-links text-center mt-2 mb-3">
          <asp:button id="btnSignIn" OnClick="btn_SignIn" class="btn btn-block btn-primary" runat="server" type="submit"  style="height: 50px" Text="Sign In"></asp:button>
     
      </div>
      <!-- /.social-auth-links -->
      </form>

	 <div id="WarningAlertMessage" runat="server" class="alert alert-danger" role="alert" Visible="false">				
	 </div>

	   <div id="CautionMessage" runat="server" class="alert alert-warning"  role="alert" Visible="false">
       </div>   

      <%--<p class="mb-1">
        <a href="forgot-password.html">I forgot my password</a>
      </p>
      <p class="mb-1">
        <a href="register.html" class="text-center">Register a new membership</a>
      </p>--%>
    </div>
    <!-- /.card-body -->
  </div>
  <!-- /.card -->
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>


</body>

</html>
