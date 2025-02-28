﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250228081750_OperationValuesTable")]
    partial class OperationValuesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("DAL.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DAL.Follower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int?>("FollowingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follower");
                });

            modelBuilder.Entity("DAL.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetadataId")
                        .HasColumnType("int");

                    b.Property<Guid>("Ref")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MetadataId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DAL.ImagesCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ImageId");

                    b.ToTable("ImagesCollection");
                });

            modelBuilder.Entity("DAL.Metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("GenDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Guidance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Lora1Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Lora1Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Lora2Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Lora2Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("PromptNeg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromptPoz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sampler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheduler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Seed")
                        .HasColumnType("bigint");

                    b.Property<int>("Steps")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lora1Id");

                    b.HasIndex("Lora2Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("DAL.Model", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Trigger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PublisherId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("DAL.Operation", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("DAL.OperationValue", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("OperationVal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("OperationValues");
                });

            modelBuilder.Entity("DAL.OperationsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OperationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("UserId");

                    b.ToTable("OperationsHistory");
                });

            modelBuilder.Entity("DAL.ProfilePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Ref")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilePicture");
                });

            modelBuilder.Entity("DAL.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("DAL.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Comment", b =>
                {
                    b.HasOne("DAL.Image", "Image")
                        .WithMany("Comments")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Follower", b =>
                {
                    b.HasOne("DAL.User", "UserFollower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.User", "UserFollowing")
                        .WithMany("Following")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserFollower");

                    b.Navigation("UserFollowing");
                });

            modelBuilder.Entity("DAL.Image", b =>
                {
                    b.HasOne("DAL.Metadata", "Metadata")
                        .WithOne("Image")
                        .HasForeignKey("DAL.Image", "MetadataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metadata");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.ImagesCollection", b =>
                {
                    b.HasOne("DAL.Collection", "Collection")
                        .WithMany("ImagesCollection")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Image", "Image")
                        .WithMany("Collections")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("DAL.Metadata", b =>
                {
                    b.HasOne("DAL.Model", "Lora1")
                        .WithMany("Lora1Metadata")
                        .HasForeignKey("Lora1Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DAL.Model", "Lora2")
                        .WithMany("Lora2Metadata")
                        .HasForeignKey("Lora2Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DAL.Model", "Model")
                        .WithMany("ModelMetadata")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Lora1");

                    b.Navigation("Lora2");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("DAL.Model", b =>
                {
                    b.HasOne("DAL.User", "Publisher")
                        .WithMany("Models")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("DAL.OperationValue", b =>
                {
                    b.HasOne("DAL.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("DAL.OperationsHistory", b =>
                {
                    b.HasOne("DAL.Operation", "Operation")
                        .WithMany("OperationsHistory")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.User", "User")
                        .WithMany("OperationsHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.ProfilePicture", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithOne("Picture")
                        .HasForeignKey("DAL.ProfilePicture", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Reaction", b =>
                {
                    b.HasOne("DAL.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId");

                    b.HasOne("DAL.Image", "Image")
                        .WithMany("Reactions")
                        .HasForeignKey("ImageId");

                    b.HasOne("DAL.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Tip", b =>
                {
                    b.HasOne("DAL.Image", "Image")
                        .WithMany("Tips")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.OperationsHistory", "Operation")
                        .WithOne("Tip")
                        .HasForeignKey("DAL.Tip", "OperationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("DAL.Collection", b =>
                {
                    b.Navigation("ImagesCollection");
                });

            modelBuilder.Entity("DAL.Comment", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("DAL.Image", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Comments");

                    b.Navigation("Reactions");

                    b.Navigation("Tips");
                });

            modelBuilder.Entity("DAL.Metadata", b =>
                {
                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Model", b =>
                {
                    b.Navigation("Lora1Metadata");

                    b.Navigation("Lora2Metadata");

                    b.Navigation("ModelMetadata");
                });

            modelBuilder.Entity("DAL.Operation", b =>
                {
                    b.Navigation("OperationsHistory");
                });

            modelBuilder.Entity("DAL.OperationsHistory", b =>
                {
                    b.Navigation("Tip");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("Images");

                    b.Navigation("Models");

                    b.Navigation("OperationsHistory");

                    b.Navigation("Picture")
                        .IsRequired();

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
