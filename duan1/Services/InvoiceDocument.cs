using duan1.DTO;
using duan1.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Collections.Generic;

public class InvoiceDocument : IDocument
{
    public DonHang DonHang { get; set; }
    public List<DonHangChiTietDTO> ChiTiet { get; set; }

    public InvoiceDocument(DonHang donHang, List<DonHangChiTietDTO> chiTiet)
    {
        DonHang = donHang;
        ChiTiet = chiTiet;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(20);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(12));

            page.Header().Text("HÓA ĐƠN BÁN HÀNG").FontSize(20).Bold().AlignCenter();

            page.Content().PaddingVertical(10).Column(column =>
            {
                column.Item().Text($"Mã Đơn Hàng: {DonHang.MaDH}");
                column.Item().Text($"Ngày Đặt: {DonHang.NgayDat:dd/MM/yyyy}");
                column.Item().Text($"Mã Khách Hàng: {DonHang.MaKH}");
                column.Item().Text($"Mã Nhân Viên: {DonHang.MaNV}");
                column.Item().Text($"Trạng Thái: {DonHang.TrangThai}");
                column.Item().Text($"Voucher: {DonHang.MaVoucher ?? "Không"}");

                column.Item().PaddingTop(10).Table(table =>
                {
                    // Define columns
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(4); // Tên sản phẩm
                        columns.RelativeColumn(2); // Size
                        columns.RelativeColumn(2); // Màu
                        columns.RelativeColumn(2); // Số lượng
                        columns.RelativeColumn(3); // Đơn giá
                        columns.RelativeColumn(3); // Thành tiền
                    });

                    // Header
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Tên sản phẩm").FontSize(14).Bold();
                        header.Cell().Element(CellStyle).Text("Size").FontSize(14).Bold();
                        header.Cell().Element(CellStyle).Text("Màu sắc").FontSize(14).Bold();
                        header.Cell().Element(CellStyle).Text("Số lượng").FontSize(14).Bold();
                        header.Cell().Element(CellStyle).Text("Đơn giá").FontSize(14).Bold();
                        header.Cell().Element(CellStyle).Text("Thành tiền").FontSize(14).Bold();
                    });

                    // Rows
                    foreach (var item in ChiTiet)
                    {
                        table.Cell().Element(CellStyle).Text(item.TenSP);
                        table.Cell().Element(CellStyle).Text(item.KichThuoc);
                        table.Cell().Element(CellStyle).Text(item.MauSac);
                        table.Cell().Element(CellStyle).Text(item.SoLuong.ToString());
                        table.Cell().Element(CellStyle).Text(item.DonGia.ToString("N0"));
                        table.Cell().Element(CellStyle).Text((item.SoLuong * item.DonGia).ToString("N0"));
                    }

                    // Footer row for tổng tiền
                    table.Footer(footer =>
                    {
                        footer.Cell().ColumnSpan(5).Element(CellStyle).AlignRight().Text("Tổng tiền:").FontSize(14).Bold();
                        footer.Cell().Element(CellStyle).Text(DonHang.TongTien.ToString("N0")).FontSize(14).Bold();
                    });
                });
            });

            page.Footer().AlignCenter().Text(x =>
            {
                x.Span("Cảm ơn quý khách!").FontSize(12);
            });
        });
    }

    static IContainer CellStyle(IContainer container)
    {
        return container.PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
    }
}
