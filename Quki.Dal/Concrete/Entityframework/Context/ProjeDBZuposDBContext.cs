using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using System;

namespace Quki.Dal.Concrete.Entityframework.Context
{
    public class ProjeDBZuposDBContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionZuposDB"));


            //optionsBuilder.UseSqlServer("server=94.73.145.8; database=u0556292_Quki; user id=u0556292_Quki; password=ESwm40T1DNey93O;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<RvcMenuItemDef> RvcMenuItemDef { get; set; }
        public DbSet<RvcOptionsRight> RvcOptionsRight { get; set; }
        public DbSet<RvcMenuItemPrice> RvcMenuItemPrice { get; set; }
        public DbSet<MenuItemBarcodeDef> MenuItemBarcodeDef { get; set; }
        public DbSet<SluDef> SluDef { get; set; }
        public DbSet<slu_Rvc_Relation> slu_Rvc_Relation { get; set; }
        public DbSet<SluDefWithLanguage> SluDefWithLanguage { get; set; }
        public DbSet<RvcMenuItemDefWithLanguage> RvcMenuItemDefWithLanguage { get; set; }
        public DbSet<CondimentMenuItemRelation> CondimentMenuItemRelation { get; set; }
        public DbSet<CondimentRelation> CondimentRelation { get; set; }

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



        public DbSet<Slider> Slider { get; set; }
        public DbSet<NewsAndAnnouncement> NewsAndAnnouncement { get; set; }






    }
}
