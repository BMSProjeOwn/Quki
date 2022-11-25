﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Context
{
    public class ProjeDBContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


            //optionsBuilder.UseSqlServer("server=94.73.145.8; database=u0556292_Quki; user id=u0556292_Quki; password=ESwm40T1DNey93O;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MemberShipType>()
.HasMany(p => p.MemberShipTypeWithPropertiess)
.WithOne(b => b.MemberShipTypes)
.HasForeignKey(p => p.MemberShipTypeSeqID);

            builder.Entity<MemberShipTypeWithCustomer>()
.HasOne(p => p.MemberShipType)
.WithMany(b => b.MemberShipTypeWithCustomers)
.HasForeignKey(p => p.MemberShipTypeSeqID);

            builder.Entity<MembershipProperties>()
            .HasMany(p => p.MemberShipTypeWithPropertiess)
           .WithOne(b => b.MembershipPropertiess)
         .HasForeignKey(p => p.MemberShipPropertiesSeqID);

            builder.Entity<MemberShipTypeWithProperties>()
           .HasIndex(p => new { p.MemberShipTypeSeqID, p.MemberShipPropertiesSeqID }).IsUnique();



            builder.Entity<MembershipTypePricePlane>()
.HasOne(p => p.MemberShipType)
.WithMany(b => b.MembershipTypePricePlane)
.HasForeignKey(p => p.MemberShipTypeSeqID);


            builder.Entity<Products>()
     .HasMany(p => p.ProductWithCategories)
     .WithOne(b => b.Products)
     .HasForeignKey(p => p.ProductSeqID);

            builder.Entity<Category>()
            .HasMany(p => p.ProductWithCategories)
           .WithOne(b => b.Category)
         .HasForeignKey(p => p.CategorySeqID);

            builder.Entity<ProductWithCategory>()
           .HasIndex(p => new { p.CategorySeqID, p.ProductSeqID }).IsUnique();

            builder.Entity<Category>()
           .HasOne(p => p.Depart)
           .WithMany(b => b.Categories)
           .HasForeignKey(p => p.DepartmanSeqID);

            builder.Entity<AttributeStaticValue>()
           .HasOne(p => p.AttributeStatic)
           .WithMany(b => b.AttributeStaticValue)
           .HasForeignKey(p => p.AttributeStaticSeqID);



            builder.Entity<Products>()
     .HasMany(p => p.ProductWithAttributeStaticValues)
     .WithOne(b => b.Products)
     .HasForeignKey(p => p.ProductSeqID);

            builder.Entity<AttributeStaticValue>()
            .HasMany(p => p.ProductWithAttributeStaticValues)
           .WithOne(b => b.AttributeStaticValue)
         .HasForeignKey(p => p.AttributeStaticValueSeqID);

            builder.Entity<ProductWithAttributeStaticValue>()
           .HasIndex(p => new { p.AttributeStaticValueSeqID, p.ProductSeqID }).IsUnique();


            builder.Entity<ProductImage>()
.HasOne(p => p.Products)
.WithMany(b => b.ProductImages)
.HasForeignKey(p => p.ProductSeqID);
            builder.Entity<CustomerIdentity>()
            .HasOne(p => p.Customer)
            .WithMany(b => b.CustomerIdentitys)
            .HasForeignKey(p => p.customer_def_seq);




            builder.Entity<OrdersDetail>()
.HasOne(p => p.Order)
.WithMany(b => b.OrdersDetails)
.HasForeignKey(p => p.OrdersSeqID);

            builder.Entity<OrderAudit>()
.HasOne(p => p.Order)
.WithMany(b => b.OrderAudits)
.HasForeignKey(p => p.OrdersSeqID);

            builder.Entity<UserProtoectInformation>()
.HasOne(p => p.ProtoectInformation)
.WithMany(b => b.UserProtoectInformation)
.HasForeignKey(p => p.ProtectionInformationSeqID);



            builder.Entity<Messages>()
 .HasMany(p => p.MessagesNotificationsTemplate)
 .WithOne(b => b.Messages)
 .HasForeignKey(p => p.MessagesSeqID);

            builder.Entity<NotificationTemplates>()
            .HasMany(p => p.MessagesNotificationsTemplate)
           .WithOne(b => b.NotificationTemplates)
         .HasForeignKey(p => p.NotificationTemplatesSeqID);

            builder.Entity<MessagesNotificationsTemplate>()
           .HasIndex(p => new { p.MessagesSeqID, p.NotificationTemplatesSeqID }).IsUnique();

            builder.Entity<MemberShipTypeWithCustomer>()
            .HasMany(p => p.MemberShipTypeWithCustomersPaymentChanel)
           .WithOne(b => b.MemberShipTypeWithCustomer)
         .HasForeignKey(p => p.MemberShipTypeWithCustomerSeqID);



            builder.Entity<MemberShipPaymentPlanWithPaymentChannel>()
.HasOne(p => p.MembershipTypePricePlane)
.WithMany(b => b.MemberShipPaymentPlanWithPaymentChannel)
.HasForeignKey(p => p.MemberShipTypePricePlaneSeqID);

            builder.Entity<MemberShipTypesWithPaymentChanel>()
.HasOne(p => p.MemberShipType)
.WithMany(b => b.MemberShipTypesWithPaymentChanels)
.HasForeignKey(p => p.MemberShipTypeSeqID);

        }
        public DbSet<TDepart> TDepart { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AttributeStatic> AttributeStatic { get; set; }
        public DbSet<AttributeStaticValue> AttributeStaticValue { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductWithCategory> ProductWithCategories { get; set; }
        public DbSet<ProductWithAttributeStaticValue> ProductWithAttributeStaticValues { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerIdentity> CustomerIdentitys { get; set; }
        public DbSet<MemberShipType> MemberShipTypes { get; set; }
        public DbSet<MemberShipTypesWithPaymentChanel> MemberShipTypesWithPaymentChanels { get; set; }
        public DbSet<MembershipProperties> MembershipProperties { get; set; }
        public DbSet<MemberShipTypeWithProperties> MemberShipTypeWithPropertiess { get; set; }
        public DbSet<MembershipTypePricePlane> MembershipTypePricePlane { get; set; }
        public DbSet<MemberShipPaymentPlanWithPaymentChannel> MemberShipPaymentPlanWithPaymentChannel { get; set; }
        public DbSet<MemberShipTypeWithCustomersPaymentChanel> MemberShipTypeWithCustomersPaymentChanel { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<MemberShipTypeWithCustomer> MemberShipTypeWithCustomers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAudit> OrderAudit { get; set; }
        public DbSet<OrdersDetail> OrdersDetail { get; set; }
        public DbSet<OrdersStatus> OrdersStatus { get; set; }
        public DbSet<ProtoectInformation> ProtoectInformation { get; set; }
        public DbSet<UserProtoectInformation> UserProtoectInformation { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<NotificationTemplates> NotificationTemplates { get; set; }
        public DbSet<MessagesNotificationsTemplate> MessagesNotificationsTemplate { get; set; }
        public DbSet<SPErrorCodeMessage> SPErrorCodeMessage { get; set; }

        public DbSet<SP_BANK> SP_BANK { get; set; }
        public DbSet<SP_BANK_BIN> SP_BANK_BIN { get; set; }
        public DbSet<SP_ERRORCODE> SP_ERRORCODE { get; set; }
        public DbSet<PaymentPeriodDef> PaymentPeriodDef { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<VisitorComment> VisitorComments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerType> ProducerType { get; set; }
        public DbSet<ProducerWithProduserType> ProducerWithProduserType { get; set; }
        public DbSet<ProductWithProducers> ProductWithProducers { get; set; }
        public DbSet<CustomerRatings> CustomerRatings { get; set; }
        public DbSet<RatingMark> RatingMark { get; set; }
        public DbSet<RatingTypes> RatingTypes { get; set; }
        public DbSet<CustomerFavoritesList> CustomerFavoritesList { get; set; }
        public DbSet<FavoritesListType> FavoritesListType { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }

        public DbSet<PlayListType> PlayListType { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<PlayListDetail> PlayListDetail { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Counrty> Counrty { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Languages> Languages { get; set; }

        public DbSet<TrackingType> TrackingType { get; set; }
        public DbSet<CustomerTrackingType> CustomerTrackingType { get; set; }
        public DbSet<BugTrack> BugTrack { get; set; }
        public DbSet<BugTrackDetail> BugTrackDetail { get; set; }

        public DbSet<CampaignDef> CampaignDef { get; set; }

        public DbSet<CampaignPropertiesDef> CampaignPropertiesDef { get; set; }

        public DbSet<CampaignDefWithCampaignPropertiesDef> CampaignDefWithCampaignPropertiesDef { get; set; }

        public DbSet<CampaignDefWithMemberShipType> CampaignDefWithMemberShipType { get; set; }

        public DbSet<ValueTypes> ValueTypes { get; set; }

        public DbSet<CampaignDefWithCoupon> CampaignDefWithCoupon { get; set; }

        public DbSet<ListeningRateReport> ListeningRateReport { get; set; }

        public DbSet<TodayMembersReportList> TodayMembersReportList { get; set; }

        public DbSet<ProducerAgreement> ProducerAgreement { get; set; }

        public DbSet<SelectHomeProduct> SelectHomeProduct { get; set; }

        public DbSet<ProducerAgreementWithProduct> ProducerAgreementWithProduct { get; set; }

        public DbSet<ProducerAgreementReport> ProducerAgreementReport { get; set; }

        public DbSet<FrequentlyAskedQuestions> FrequentlyAskedQuestions { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<MemberShipTypeWithCountry> MemberShipTypeWithCountry { get; set; }

        public DbSet<CancelReason> CancelReason { get; set; }
        public DbSet<MemberShipWithCancelReason> MemberShipWithCancelReason { get; set; }

        public DbSet<Payments> Payments { get; set; }

        public DbSet<ListeningRateReportByUser> ListeningRateReportByUser { get; set; }
        public DbSet<PaymentReport> PaymentReport { get; set; }
        
        public DbSet<CampaingReport> CampaingReport { get; set; }
        public DbSet<SelectUseCouponCustomers> SelectUseCouponCustomers { get; set; }

        public DbSet<SPResponse> SPResponse { get; set; }

        public DbSet<listOfExpiredMembers> listOfExpiredMembers { get; set; }
        public DbSet<NotificationTemplatess> NotificationTemplatess { get; set; }

        public DbSet<UpdateUserEmailConfirmed> UpdateUserEmailConfirmed { get; set; }

        public DbSet<CustomerNotificationLogs> CustomerNotificationLogs { get; set; }
        public DbSet<MemberShipTypePropertiesType> MemberShipTypePropertiesType { get; set; }

        public DbSet<MemberShipTypeWithCustomersProfiles> MemberShipTypeWithCustomersProfiles { get; set; }

        public DbSet<Avatars> Avatars { get; set; }

        public DbSet<Integration> Integration { get; set; }
        public DbSet<IntegrationProperties> IntegrationProperties { get; set; }

        public DbSet<ActiveProfile> ActiveProfile { get; set; }
        public DbSet<GetUserProfiles> GetUserProfiles { get; set; }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesItems> SalesItems { get; set; }
        public DbSet<SalesItemLineProperties> SalesItemLineProperties { get; set; }

        public DbSet<Branch> Branch { get; set; }
        public DbSet<Tax> Tax { get; set; }

        public DbSet<CampaignDefWithMemberShipTypePricePlane> CampaignDefWithMemberShipTypePricePlane { get; set; }
        public DbSet<SelectMemberShipPricePlaneWithCampaignCode> SelectMemberShipPricePlaneWithCampaignCode { get; set; }
        public DbSet<MemberShipWithCampaignDefCoupon> MemberShipWithCampaignDefCoupon { get; set; }

        public DbSet<CampingWithPropertiesRelationModel> CampingWithPropertiesRelationModel { get; set; }
        public DbSet<LogForTransaction> LogForTransaction { get; set; }
        public DbSet<GetAllPricePlaneSP> GetAllPricePlaneSP { get; set; }
        public DbSet<PaymentChannel> PaymentChannel { get; set; }
        public DbSet<PaymentChanelWithDeviceType> PaymentChanelWithDeviceType { get; set; }
        public DbSet<DeviceType> DeviceType { get; set; }



        

        
    }
}