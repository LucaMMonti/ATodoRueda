<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservas.aspx.cs" Inherits="ATodoRueda.GestionarReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Label ID="lblSuccessMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

       <h2>Gestión de Reservas</h2>

        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" CssClass="table"
                OnRowEditing="gvReservas_RowEditing" OnRowUpdating="gvReservas_RowUpdating" OnRowCancelingEdit="gvReservas_RowCancelingEdit" 
                OnRowDeleting="gvReservas_RowDeleting" DataKeyNames="Id">
                    <Columns>

                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>

                        <asp:TemplateField HeaderText="Vehículo ID">
                            <ItemTemplate>
                                <asp:Label ID="lblVehiculoId" runat="server" Text='<%# Bind("VehiculoId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtVehiculoId" runat="server" Text='<%# Bind("VehiculoId") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Usuario ID">
                            <ItemTemplate>
                                <asp:Label ID="lblUsuarioId" runat="server" Text='<%# Bind("UsuarioId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Reserva">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaReserva" runat="server" Text='<%# Bind("FechaReserva", "{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblFechaReservaEdit" runat="server" Text='<%# Bind("FechaReserva", "{0:yyyy-MM-dd}") %>' CssClass="form-control"></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Inicio">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaInicio" runat="server" Text='<%# Eval("FechaInicio") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFechaInicio" runat="server" Text='<%# Eval("FechaInicio") %>' CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Fin">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Eval("FechaFin") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFechaFin" runat="server" Text='<%# Eval("FechaFin") %>' CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio Total">
                            <ItemTemplate>
                                <asp:Label ID="lblPrecioTotal" runat="server" Text='<%# Bind("PrecioTotal") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecioTotal" runat="server" Text='<%# Bind("PrecioTotal") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="Promoción ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPromocionId" runat="server" Text='<%# Bind("PromocionId") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPromocionId" runat="server" Text='<%# Bind("PromocionId") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                      <asp:TemplateField HeaderText="Pagado">
                           <ItemTemplate>
                               <asp:CheckBox ID="chkPagado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Pagado")) %>' Enabled="false" />
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:CheckBox ID="chkPagadoEdit" runat="server" Checked='<%# Bind("Pagado") %>' />
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


    <asp:Button ID="btnMostrarModalAgregarReserva" runat="server" Text="Agregar Nueva Reserva" CssClass="btn btn-primary" OnClientClick="mostrarModalAgregarReserva(); return false;" />

    <div class="modal fade" id="modalAgregarReserva" tabindex="-1" role="dialog" aria-labelledby="modalAgregarReservaLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modalAgregarReservaLabel">Agregar Nueva Reserva</h5>
          </div>
          <div class="modal-body">          
            <asp:DropDownList ID="ddlVehiculos" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
            <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
            <asp:TextBox ID="txtFechaR" runat="server" CssClass="form-control mb-2" Placeholder="Fecha Reserva" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="txtFechaIni" runat="server" CssClass="form-control mb-2" Placeholder="Fecha Inicio" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="txtFechaF" runat="server" CssClass="form-control mb-2" Placeholder="Fecha Inicio" TextMode="Date"></asp:TextBox>
            <asp:TextBox ID="txtPromo" runat="server" CssClass="form-control mb-2" Placeholder="Promoción"></asp:TextBox>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="$('#modalAgregarReserva').modal('hide');">Cancelar</button>
            <asp:Button ID="btnGuardarReservas" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarReservas_Click" />
          </div>
        </div>
      </div>
    </div>


    <script type="text/javascript">
        function mostrarModalAgregarReserva() {
            $('#modalAgregarReserva').modal('show');
        }
    </script>


</asp:Content>
