<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="ATodoRueda.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hiddenUserId" runat="server" />

    <h2>Gestión de Usuarios</h2>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false" AutoPostBack="false"></asp:Label>

        <!-- Pesteñas -->
    <ul class="nav nav-tabs" id="myTab" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Lista de Usuarios</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" id="agregar-tab" data-toggle="tab" href="#agregar" role="tab" aria-controls="agregar" aria-selected="false">Agregar Usuario</a>
        </li>
    </ul>

    <div class="tab-content" id="myTabContent">
        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered" DataKeyNames="Id">
             <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Contrasena" HeaderText="Contraseña" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" />
                <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}"/> 
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" /> 
                <asp:TemplateField HeaderText="Rol">
                     <ItemTemplate>
                        <asp:Label ID="lblRol" runat="server" Text='<%# GetRolName(Eval("Rol").ToString()) %>'></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>             

             </Columns>
             </asp:GridView>
    </div>
</div>

 <div class="tab-pane fade" id="agregar" role="tabpanel" aria-labelledby="agregar-tab">
    <h3>Agregar nuevo usuario:</h3>
    <asp:Panel ID="PanelNuevoUsuario" runat="server" CssClass="container">

        <!-- Fila 1: Nombre, Apellido, Correo Electrónico -->
        <div class="row">
            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="txtNombre" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="txtApellido" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="txtCorreoElectronico" Text="Correo electrónico: "></asp:Label>
                <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
        </div>
        
        <!-- Fila 2: Contraseña, Fecha de Nacimiento, Teléfono -->
        <div class="row">
            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="txtContrasena" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="txtFechaNacimiento">Fecha de nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server" />
            </div>
            <div class="form-group col-md-4">
                <label for="txtTelefono">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <!-- Fila 3: Dirección, Rol, Botón Agregar -->
        <div class="row">
           <div class="form-group col-md-4">
                <label for="txtNumeroDocumento">Número Documento:</label>
                <asp:TextBox ID="txtNumeroDocumento" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group col-md-4">
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" />
            </div>

            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="ddlNuevoRol" Text="Rol: "></asp:Label>
                <asp:DropDownList ID="ddlNuevoRol" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-4 d-flex align-items-end">
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario" OnClick="btnAgregarUsuario_Click" CssClass="btn btn-primary w-100" />
            </div>
        </div>
    </asp:Panel>
</div>

    <script>
        $(document).ready(function () {
            $('.nav-tabs a').click(function () {
                $(this).tab('show');
            });
        });
    </script>

</asp:Content>
