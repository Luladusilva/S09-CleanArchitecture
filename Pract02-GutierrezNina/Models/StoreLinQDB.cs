using Microsoft.EntityFrameworkCore;

namespace Pract02_GutierrezNina.Models;

public partial class StoreLinQDB : DbContext
{
    public StoreLinQDB()
    {
    }

    public StoreLinQDB(DbContextOptions<StoreLinQDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(client => client.ClientId).HasName("clients_pkey");
            entity.ToTable("clients");
            entity.Property(client => client.ClientId).HasColumnName("client_id");
            entity.Property(client => client.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(client => client.Name).HasMaxLength(100).HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(order => order.OrderId).HasName("orders_pkey");
            entity.ToTable("orders");
            entity.Property(order => order.OrderId).HasColumnName("order_id");
            entity.Property(order => order.ClientId).HasColumnName("client_id");
            entity.Property(order => order.OrderDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_date");
            entity.HasOne(order => order.Client).WithMany(client => client.Orders)
                .HasForeignKey(order => order.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_clients");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(detail => detail.OrderDetailId).HasName("order_details_pkey");
            entity.ToTable("order_details");
            entity.Property(detail => detail.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(detail => detail.OrderId).HasColumnName("order_id");
            entity.Property(detail => detail.ProductId).HasColumnName("product_id");
            entity.Property(detail => detail.Quantity).HasColumnName("quantity");
            entity.HasOne(detail => detail.Order).WithMany(order => order.OrderDetails)
                .HasForeignKey(detail => detail.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_details_orders");
            entity.HasOne(detail => detail.Product).WithMany(product => product.OrderDetails)
                .HasForeignKey(detail => detail.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_details_products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(product => product.ProductId).HasName("products_pkey");
            entity.ToTable("products");
            entity.Property(product => product.ProductId).HasColumnName("product_id");
            entity.Property(product => product.Description).HasMaxLength(100).HasColumnName("description");
            entity.Property(product => product.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(product => product.Price).HasPrecision(10, 2).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
