<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionPromociones.aspx.cs" Inherits="ATodoRueda.GestionPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblSuccessMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

       <h2>Gestión de Promociones</h2>

        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                <asp:GridView ID="gvPromociones" runat="server" AutoGenerateColumns="False" CssClass="table"
                OnRowEditing="gvPromociones_RowEditing" OnRowUpdating="gvPromociones_RowUpdating" OnRowCancelingEdit="gvPromociones_RowCancelingEdit" 
                OnRowDeleting="gvPromociones_RowDeleting" DataKeyNames="Id">
                    <Columns>

                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>

                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCodigo" runat="server" Text='<%# Bind("Codigo") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descuento">
                            <ItemTemplate>
                                <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescuento" runat="server" Text='<%# Bind("Descuento") %>' CssClass="form-control"></asp:TextBox>
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

                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="false" />


                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" 
                                Text="Eliminar" OnClientClick='return confirm("¿Estás seguro que deseas eliminar este registro?");' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>


    <asp:Button ID="btnMostrarModalAgregarPromocion" runat="server" Text="Agregar Nueva Promoción" CssClass="btn btn-primary" OnClientClick="mostrarModalAgregarPromocion(); return false;" />

    <div class="modal fade" id="modalAgregarPromocion" tabindex="-1" role="dialog" aria-labelledby="modalAgregarPromocionLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modalAgregarPromocionLabel">Agregar Nueva Promoción</h5>
          </div>
          <div class="modal-body">
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control mb-2" Placeholder="Código"></asp:TextBox>
            <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control mb-2" Placeholder="Descuento"></asp:TextBox>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="$('#modalAgregarPromocion').modal('hide');">Cancelar</button>
            <asp:Button ID="btnGuardarPromocion" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarPromocion_Click" />
          </div>
        </div>
      </div>
    </div>


    <script type="text/javascript">
        function mostrarModalAgregarPromocion() {
            $('#modalAgregarPromocion').modal('show');
        }
    </script>




</asp:Content>
