using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuanLyKho.Data;

namespace QuanLyKho.Data.Migrations
{
    [DbContext(typeof(AppsDbContext))]
    [Migration("20170309063851_initialDb_09032017")]
    partial class initialDb_09032017
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuanLyKho.Model.Models.ContactDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat");

                    b.Property<double?>("Lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Other");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Error", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("ID");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Message")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Footer", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DisplayOrder");

                    b.Property<int>("GroupID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Target")
                        .HasMaxLength(10);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.MenuGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("MenuGroups");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerId")
                        .HasMaxLength(128);

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(250);

                    b.Property<string>("PaymentStatus");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderID", "ProductID");

                    b.HasAlternateKey("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Page", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.PostCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.PostTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("PostID");

                    b.HasKey("TagID", "PostID");

                    b.HasAlternateKey("PostID");


                    b.HasAlternateKey("PostID", "TagID");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("MoreImages")
                        .HasColumnType("xml");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("OriginalPrice");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PromotionPrice");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Status");

                    b.Property<string>("Tags");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.Property<int?>("Warranty");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("ParentID");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.ProductTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasMaxLength(50);

                    b.Property<int>("ProductID");

                    b.HasKey("TagID", "ProductID");

                    b.HasAlternateKey("ProductID");


                    b.HasAlternateKey("ProductID", "TagID");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.SupportOnline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasMaxLength(50);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("Mobile")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Skype")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Yahoo")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SupportOnlines");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.SystemConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ValueInt");

                    b.Property<string>("ValueString")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Tag", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(250);

                    b.Property<string>("MetaKeyWord")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.VisitorStatistic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50);

                    b.Property<DateTime>("VisitedDate");

                    b.HasKey("ID");

                    b.ToTable("VisitorStatistics");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Menu", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.MenuGroup", "MenuGroup")
                        .WithMany("Menus")
                        .HasForeignKey("GroupID");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.OrderDetail", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID");

                    b.HasOne("QuanLyKho.Model.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Post", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.PostCategory", "PostCategories")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.PostTag", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostID");

                    b.HasOne("QuanLyKho.Model.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.Product", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("QuanLyKho.Model.Models.ProductTag", b =>
                {
                    b.HasOne("QuanLyKho.Model.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductID");

                    b.HasOne("QuanLyKho.Model.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });
        }
    }
}
