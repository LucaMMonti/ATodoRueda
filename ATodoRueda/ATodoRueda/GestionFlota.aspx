<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionFlota.aspx.cs" Inherits="ATodoRueda.GestionFlota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="False" CssClass="table"
    OnRowEditing="gvVehiculos_RowEditing" OnRowUpdating="gvVehiculos_RowUpdating" OnRowDeleting="gvVehiculos_RowDeleting"
        OnRowDataBound="gvVehiculos_RowDataBound" DataKeyNames="Id" >
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>

        <asp:TemplateField HeaderText="Tipo">
            <ItemTemplate>
                <asp:Label ID="lblTipo" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Marca">
            <ItemTemplate>
                <asp:Label ID="lblMarca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtMarca" runat="server" Text='<%# Bind("Marca") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>   
        
        <asp:TemplateField HeaderText="Modelo">
            <ItemTemplate>
                <asp:Label ID="lblModelo" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtModelo" runat="server" Text='<%# Bind("Modelo") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Color">
            <ItemTemplate>
                <asp:Label ID="lblColor" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtColor" runat="server" Text='<%# Bind("Color") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Año">
            <ItemTemplate>
                <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAnio" runat="server" Text='<%# Bind("Anio") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Placa">
            <ItemTemplate>
                <asp:Label ID="lblPlaca" runat="server" Text='<%# Bind("Placa") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPlaca" runat="server" Text='<%# Bind("Placa") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Precio">
            <ItemTemplate>
                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    
        <asp:TemplateField HeaderText="Descripcion">
            <ItemTemplate>
                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" ReadOnly="true" />

        <asp:TemplateField HeaderText="Disponibilidad">
            <ItemTemplate>
                <asp:Label ID="lblDisponibilidad" runat="server" Text='<%# Bind("Disponibilidad") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDisponibilidad" runat="server" Text='<%# Bind("Disponibilidad") %>' CssClass="form-control"></asp:TextBox>
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
        

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
    </asp:GridView>
<asp:Button ID="btnMostrarModalAgregarVehiculo" runat="server" Text="Agregar Nuevo Vehículo" CssClass="btn btn-primary" OnClientClick="mostrarModalAgregarVehiculo(); return false;" />

    <div class="modal fade" id="modalAgregarVehiculo" tabindex="-1" role="dialog" aria-labelledby="modalAgregarVehiculoLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modalAgregarVehiculoLabel">Agregar Nuevo Vehículo</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control mb-2">
                <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                <asp:ListItem Text="SUV" Value="SUV"></asp:ListItem>
                <asp:ListItem Text="Camioneta" Value="Camioneta"></asp:ListItem>
            </asp:DropDownList>            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control mb-2" Placeholder="Marca"></asp:TextBox>
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control mb-2" Placeholder="Modelo"></asp:TextBox>
            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control mb-2" Placeholder="Color"></asp:TextBox>
            <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control mb-2" Placeholder="Año"></asp:TextBox>
            <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control mb-2" Placeholder="Placa"></asp:TextBox>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control mb-2" Placeholder="Precio"></asp:TextBox>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control mb-2" Placeholder="Descripcion"></asp:TextBox>
            <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control mb-2" Placeholder="Imagen"></asp:TextBox>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            <asp:Button ID="btnGuardarVehiculo" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarVehiculo_Click" />
          </div>
        </div>
      </div>
    </div>


    <script type="text/javascript">
        function mostrarModalAgregarVehiculo() {
            $('#modalAgregarVehiculo').modal('show');
        }
    </script>

</asp:Content>
