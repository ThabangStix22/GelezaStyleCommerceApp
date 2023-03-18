<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GelezaStyleWebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterAboveHtml" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterAboveHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MasterHeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MasterAboveBody" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MasterBodyPlaceHolder" runat="server">
 
 style="text-align: center;">
		<h1 style="color: green;">
			GeeksforGeeks
		</h1>
		<p>
		Click on the button to create
		a form dynamically
		</p>
		<button onClick="CreateForm()">
			click here
		</button>
		<p id="GFG_DOWN"></p>
<script>
    var down = document.getElementById("formWrapper");
		
	// Create a break line element
	var br = document.createElement("br");
	function CreateForm() {
			
	// Create a form dynamically
	var form = document.createElement("");
	form.setAttribute("method", "post");
	form.setAttribute("action", "submit.php");

	// Create an input element for Full Name
	var FN = document.createElement("input");
	FN.setAttribute("type", "text");
	FN.setAttribute("name", "FullName");
	FN.setAttribute("placeholder", "Full Name");

	// Create an input element for date of birth
	var DOB = document.createElement("input");
	DOB.setAttribute("type", "text");
	DOB.setAttribute("name", "dob");
	DOB.setAttribute("placeholder", "DOB");

	// Create an input element for emailID
	var EID = document.createElement("input");
	EID.setAttribute("type", "text");
	EID.setAttribute("name", "emailID");
	EID.setAttribute("placeholder", "E-Mail ID");

	// Create an input element for password
	var PWD = document.createElement("input");
	PWD.setAttribute("type", "password");
	PWD.setAttribute("name", "password");
	PWD.setAttribute("placeholder", "Password");

	// Create an input element for retype-password
	var RPWD = document.createElement("input");
	RPWD.setAttribute("type", "password");
	RPWD.setAttribute("name", "reTypePassword");
	RPWD.setAttribute("placeholder", "ReEnter Password");

				// create a submit button
				var s = document.createElement("input");
				s.setAttribute("type", "submit");
				s.setAttribute("value", "Submit");
				
				// Append the full name input to the form
				form.appendChild(FN);
				
				// Inserting a line break
				form.appendChild(br.cloneNode());
				
				// Append the DOB to the form
				form.appendChild(DOB);
				form.appendChild(br.cloneNode());
				
				// Append the emailID to the form
				form.appendChild(EID);
				form.appendChild(br.cloneNode());
				
				// Append the Password to the form
				form.appendChild(PWD);
				form.appendChild(br.cloneNode());
				
				// Append the ReEnterPassword to the form
				form.appendChild(RPWD);
				form.appendChild(br.cloneNode());
				
				// Append the submit button to the form
				form.appendChild(s);

				document.getElementsByTagName("body")[0]
			.appendChild(form);
			}
</script>
	</>

</asp:Content>


 <form runat="server" >

   <div  id="formWrapper" class="content-wrapper">
    <!-- Main content -->
    <section class="content">
           
      <div class="row">
         
        <div class="col-md-6">
                 
          <div class="card card-primary"  id="RegistrationBox" runat="server" Visible="true">
            <div class="card-header">
              <h3 class="card-title">Add New Stock Item</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">



                  <div class="form-group">
                     <label for="inputImage" >Upload Image</label>
                     <asp:FileUpload ID="FileUpload" class="form-control" runat="server" OnClick="btn_FileUpload" />
                 </div>



              <div class="form-group">
                <label for="inputName" >Item Name</label>
                <input type="text" id="inputName" class="form-control" runat="server" required placeholder="e.g Royal Blazer">
              </div>


              <div class="form-group">
                <label for="inputDescription" >Item Description</label>
                <textarea id="inputDescription" class="form-control" rows="4" runat="server"></textarea>
              </div>
         
              <div class="form-group">
                <label for="inputPrice">Item Price</label>
                <input type="number" id="inputPrice" class="form-control" runat="server" min="15" maxlength="4" required placeholder="e.g R120">
              </div>

              <div class="form-group">
                <label for="inputUnits">Item Units</label>
                <input type="number" id="inputUnits" class="form-control" runat="server" min="10" required placeholder="minimum 10">
              </div>

                <div class="form-group">
                  <label>Category</label>
                  <select id="selectCategory" runat="server" class="form-control select2 select2-hidden-accessible" style="width: 100%;" data-select2-id="1" tabindex="-1" aria-hidden="true">
                    <option disabled selected>-Select Category-</option>
                    <option value="Blazer">Blazer</option>
                    <option value="Dress">Dress</option>
                    <option value="Jersey">Jersey</option>
                    <option value="Shirt">Shirt</option>
                    <option value="Shoes">Shoes</option>
                    <option value="Skirt">Skirt</option>
                    <option value="Socks">Socks</option>
                    <option value="Tie">Tie</option>
                    <option value="Trouser">Trouser</option>
                  </select>
          
                </div>
          
                 <div class="form-group" data-select2-id="29">
                  <label>Item Size</label>
                  <asp:ListBox ID="selectSize" runat="server" class="select2 select2-hidden-accessible"
                      selectionMode="Multiple" multiple="true" data-placeholder="-Select a Size-" style="width: 100%;" 
                      tabindex="-1" aria-hidden="true" required="required">

                      <asp:ListItem Text="One Size" Value="One Size"/>

                      <asp:ListItem Text="Size 1" Value="1"/>
                      <asp:ListItem Text="Size 2" Value="2"/>
                      <asp:ListItem Text="Size 3" Value="3"/>
                      <asp:ListItem Text="Size 4" Value="4"/>
                      <asp:ListItem Text="Size 5" Value="5"/>
                      <asp:ListItem Text="Size 6" Value="6"/>
                      <asp:ListItem Text="Size 7" Value="7"/>
                      <asp:ListItem Text="Size 8" Value="8"/>
                      <asp:ListItem Text="Size 9" Value="9"/>
                      <asp:ListItem Text="Size 10" Value="10"/>

                      <asp:ListItem Text="Small" Value="Small"/>
                      <asp:ListItem Text="Medium" Value="Medium"/>
                      <asp:ListItem Text="Large" Value="Large"/>
                      <asp:ListItem Text="X-Large" Value="XL"/>
                      <asp:ListItem Text="XXL" Value="XXL"/>


                       <asp:ListItem Text="28" Value="28"/>
                       <asp:ListItem Text="29" Value="29"/>
                       <asp:ListItem Text="30" Value="30"/>
                       <asp:ListItem Text="31" Value="31"/>
                       <asp:ListItem Text="32" Value="32"/>
                       <asp:ListItem Text="33" Value="33"/>
                       <asp:ListItem Text="34" Value="34"/>
                       <asp:ListItem Text="35" Value="35"/>
                       <asp:ListItem Text="36" Value="36"/>
                       <asp:ListItem Text="37" Value="37"/>
                       <asp:ListItem Text="38" Value="38"/>
                       <asp:ListItem Text="39" Value="39"/>
                       <asp:ListItem Text="40" Value="40"/>
                       <asp:ListItem Text="41" Value="41"/>
                       <asp:ListItem Text="42" Value="42"/>
                  </asp:ListBox>
                </div>
           

          

                   <div class="form-group">
                  <label>Gender</label>
                  <select id="selectGender" runat="server" class="form-control select2 select2-hidden-accessible" style="width: 100%;" data-select2-id="1" tabindex="-1" aria-hidden="true">
                    <option disabled selected>-Select Gender-</option>
                    <option value="Boys">Boys</option>
                    <option value="Girls">Girls</option>
                    <option value="Unisex">Unisex</option>
                  </select>
          
                </div>

              </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        
      </div>
      <div class="row" >
        <div class="col-12">
            
          <div id="ActionButtons" runat="server">
          <a href="Manage_Schools.aspx" class="btn btn-secondary">Cancel</a>
          <asp:button OnClick="btnCreateItem" runat="server" type="submit" text="Create new Item" class="btn btn-success float-right"></asp:button>
          </div> 

        </div>
      </div>
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
        
 </form>
              