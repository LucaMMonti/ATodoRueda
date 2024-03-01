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
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id"
            AutoGenerateEditButton="True" OnRowEditing="gvUsuarios_RowEditing" OnRowUpdating="gvUsuarios_RowUpdating" OnRowCancelingEdit="gvUsuarios_RowCancelingEdit"
            OnRowDataBound="gvUsuarios_RowDataBound">
             <Columns>

                 <asp:TemplateField HeaderText="Nombre">
                     <ItemTemplate>
                         <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="Apellido">
                     <ItemTemplate>
                         <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtApellido" runat="server" Text='<%# Bind("Apellido") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField> 

                 <asp:TemplateField HeaderText="Contraseña">
                     <ItemTemplate>
                         <asp:Label ID="lblContrasena" runat="server" Text='<%# Bind("Contrasena") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtContrasena" runat="server" Text='<%# Bind("Contrasena") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="Correo Electronico">
                     <ItemTemplate>
                         <asp:Label ID="lblCorreoElectronico" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtCorreoElectronico" runat="server" Text='<%# Bind("CorreoElectronico") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="N° Documento">
                     <ItemTemplate>
                         <asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Bind("NumeroDocumento") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtNumeroDocumento" runat="server" Text='<%# Bind("NumeroDocumento") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="Fecha de Nacimiento">
                     <ItemTemplate>
                         <asp:Label ID="lblFechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtFechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>' CssClass="form-control" TextMode="Date"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField> 

                 <asp:TemplateField HeaderText="Teléfono">
                     <ItemTemplate>
                         <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Bind("Telefono") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="Dirección">
                     <ItemTemplate>
                         <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtDireccion" runat="server" Text='<%# Bind("Direccion") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField> 

                <asp:TemplateField HeaderText="Rol">
                    <ItemTemplate>
                        <asp:Label ID="lblRol" runat="server" Text='<%# GetRolName(Eval("Rol").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Gestor" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Cliente" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>    
                 
                <asp:TemplateField HeaderText="Activo">
                    <ItemTemplate>
                       <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Estado")) %>' Enabled="false" />
                   </ItemTemplate>
                   <EditItemTemplate>
                       <asp:CheckBox ID="chkEstadoEdit" runat="server" Checked='<%# Bind("Estado") %>' />
                   </EditItemTemplate>
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
