using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eproject2025.Models;

public partial class OnlineBookStoreContext : DbContext
{
    public OnlineBookStoreContext()
    {
    }

    public OnlineBookStoreContext(DbContextOptions<OnlineBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BookDetail> BookDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cddetail> Cddetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Dvddetail> Dvddetails { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Online_BookStore;uid=sa;pwd=hai03112k5;TrustServerCertificate=true;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__43AA4141ED4F67D7");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__B9BE370EE9ACF1C4").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Admin__user_id__40058253");
        });

        modelBuilder.Entity<BookDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__BookDeta__47027DF525BAFE26");

            entity.ToTable("BookDetail");

            entity.Property(e => e.ProductId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("author");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .HasColumnName("language");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");

            entity.HasOne(d => d.Product).WithOne(p => p.BookDetail)
                .HasForeignKey<BookDetail>(d => d.ProductId)
                .HasConstraintName("FK_BookDetail_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B47F4E5D37");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Cddetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__CDDetail__47027DF554D0ECD2");

            entity.ToTable("CDDetail");

            entity.Property(e => e.ProductId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.Artist)
                .HasMaxLength(100)
                .HasColumnName("artist");
            entity.Property(e => e.CapacityMb).HasColumnName("capacity_mb");
            entity.Property(e => e.CdType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cd_type");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");

            entity.HasOne(d => d.Product).WithOne(p => p.Cddetail)
                .HasForeignKey<Cddetail>(d => d.ProductId)
                .HasConstraintName("FK_CDDetail_Product");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB85513BE9DD");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.UserId, "UQ__Customer__B9BE370EFD9E0D0C").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.DistanceKm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("distance_km");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Customer__user_i__3C34F16F");
        });

        modelBuilder.Entity<Dvddetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__DVDDetai__47027DF541C5BEC2");

            entity.ToTable("DVDDetail");

            entity.Property(e => e.ProductId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.DvdType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dvd_type");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("region_code");

            entity.HasOne(d => d.Product).WithOne(p => p.Dvddetail)
                .HasForeignKey<Dvddetail>(d => d.ProductId)
                .HasConstraintName("FK_DVDDetail_Product");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PK__FAQ__66734BAF653A4AE9");

            entity.ToTable("FAQ");

            entity.Property(e => e.FaqId).HasColumnName("faq_id");
            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__7A6B2B8CD3DE0565");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__465962296597740D");

            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("order_id");
            entity.Property(e => e.DeliveryCharge)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("delivery_charge");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("payment_status");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("payment_type");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Processing")
                .HasColumnName("status");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TotalAmount)
                .HasComputedColumnSql("([subtotal]+[delivery_charge])", true)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_It__3764B6BC7EA6F2A4");

            entity.ToTable("Order_Items");

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("order_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([quantity]*[unit_price])", true)
                .HasColumnType("decimal(21, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF54275C4FA");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");
            entity.Property(e => e.SubcategoryId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subcategory_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Products)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Publisher");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("FK_Product_SubCategory");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__3213E83F53F53D48");

            entity.ToTable("Publisher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("PK__SubCateg__F7A5CC2652E8F7F6");

            entity.ToTable("SubCategory");

            entity.Property(e => e.SubcategoryId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subcategory_id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category_id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("manufacturer");
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subcategory_name");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__SubCatego__categ__0F624AF8");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__B9BE370F4E6CDDA3");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.Username, "UQ__UserAcco__F3DBC5721E1B9673").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
