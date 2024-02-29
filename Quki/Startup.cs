using AspNetCore.SEOHelper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Quki.Bll;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Dal.Concrete.Entityframework.UnitOfWork;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.Models;

using static Quki.Entity.Statics.Enums;

namespace Quki
{
    public class Startup
    {
        public static int Progress { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddDbContext<ProjeDBContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<ProjeDBZuposDBContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionZuposDB")));
            //services.AddControllersWithViews();

            services.AddDbContext<ProjeDBContext>();
            services.AddDbContext<ProjeDBZuposDBContext>();
            //services.AddAuthentication();

            services.AddScoped<DbContext, ProjeDBContext>();
            //services.AddScoped(typeof(IGenericService<,>), typeof(BllBase<,>));
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            #region Servis section
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IActiveProfileService, ActiveProfileManager>();
            services.AddScoped<IAgreementService, AgreementManager>();
            services.AddScoped<IProducerAgreementWithProductService, ProducerAgreementWithProductManager>();
            services.AddScoped<IAttributeStaticService, AttributeStaticManager>();
            services.AddScoped<IAttributeStaticValueService, AttributeStaticValueManager>();
            services.AddScoped<IAvatarsService, AvatarManager>();
            services.AddScoped<IBeneficiaryService, BeneficiaryManager>();
            services.AddScoped<IBugTrackDetailService, BugTrackDetailManager>();
            services.AddScoped<ICampaignDefWithCampaignPropertiesDefService, CampaignDefWithCampaignPropertiesDefManager>();
            services.AddScoped<ICampaignDefWithCampaignPropertiesService, CampaignDefWithCampaignPropertiesManager>();
            services.AddScoped<ICampaignDefWithCouponService, CampaignDefWithCouponManager>();
            services.AddScoped<ICampaignDefWithMemberShipTypePricePlaneService, CampaignDefWithMemberShipTypePricePlaneManager>();
            services.AddScoped<ICampaignDefWithMemberShipTypeService, CampaignDefWithMemberShipTypeManager>();
            services.AddScoped<ICampaignPropertiesDefService, CampaignPropertiesDefManager>();
            services.AddScoped<ICampaignService, CampaignManager>();
            services.AddScoped<ICancelReasonService, CancelReasonManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<ICustomerFovoriListService, CustomerFovoriListManager>();
            services.AddScoped<ICustomerIdentitysService, CustomerIdentitysManager>();
            services.AddScoped<ICustomerNotificationLogsService, CustomerNotificationLogsManager>();
            services.AddScoped<ICustomerRatingsService, CustomerRatingsManager>();
            services.AddScoped<ICustomerTrackingTypeService, CustomerTrackingTypeManager>();
            services.AddScoped<IDepartmentsService, DepartmentsManager>();
            services.AddScoped<IDocumentsService, DocumentsManager>();
            services.AddScoped<IEmailTemplateService, EmailTemplateManager>();
            services.AddScoped<IErrorLogService, ErrorLogManager>();
            services.AddScoped<IFrequentlyAskedQuestionsService, FrequentlyAskedQuestionsManager>();
            services.AddScoped<IIntegrationPropertiesService, IntegrationPropertiesManager>();
            services.AddScoped<IIntegrationService, IntegrationManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<IMediaTypesService, MediaTypesManager>();
            services.AddScoped<IMemberShipPaymentPlanWithPaymentChannelService, MemberShipPaymentPlanWithPaymentChannelManager>();
            services.AddScoped<IMembershipPropertiesService, MembershipPropertiesManager>();
            services.AddScoped<IMemberShipTypeService, MemberShipTypeManager>();
            services.AddScoped<IMembershipTypePricePlaneService, MembershipTypePricePlaneManager>();
            services.AddScoped<IMemberShipTypePropertiesTypeService, MemberShipTypePropertiesTypeManager>();
            services.AddScoped<IMemberShipTypeWithCustomerService, MemberShipTypeWithCustomerManager>();
            services.AddScoped<IMemberShipTypeWithCustomersProfilesService, MemberShipTypeWithCustomersProfilesManager>();
            services.AddScoped<IMemberShipTypeWithPropertiesService, MemberShipTypeWithPropertiesManager>();
            services.AddScoped<IMemberShipWithCampaignDefCouponService, MemberShipWithCampaignDefCouponManager>();
            services.AddScoped<IMemberShipWithCancelReasonService, MemberShipWithCancelReasonManager>();
            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IMessagesService, MessagesManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IPaymentTransactionService, PaymentTransactionManager>();
            services.AddScoped<IPlayListService, PlayListManager>();
            services.AddScoped<IPlayListDetailService, PlayListDetailManager>();
            services.AddScoped<IProducersService, ProducersManager>();
            services.AddScoped<IProducerTypeService, ProducerTypeManager>();
            services.AddScoped<IPaymentPeriodDefService, PaymentPeriodDefManager>();
            services.AddScoped<IProducerWithProduserTypeService, ProducerWithProduserTypeManager>();
            services.AddScoped<IProductImagesService, ProductImagesManager>();
            services.AddScoped<IProductWithAttributeStaticValueService, ProductWithAttributeStaticValueManager>();
            services.AddScoped<IProductWithCategoryService, ProductWithCategoryManager>();
            services.AddScoped<IProductWithProducersService, ProductWithProducersManager>();
            services.AddScoped<IProtoectInformationService, ProtoectInformationManager>();
            services.AddScoped<ISalesItemsService, SalesItemsManager>();
            services.AddScoped<ITestService, TestManager>();
            services.AddScoped<IUserProfileService, UserProfileManager>();
            services.AddScoped<IUserProtoectInformationService, UserProtoectInformationManager>();
            services.AddScoped<IValueTypesService, ValueTypesManager>();
            services.AddScoped<IVisitorCommentService, VisitorCommentsManager>();
            services.AddScoped<IMemberShipTypeWithCountryService, MemberShipTypeWithCountryManager>();
            services.AddScoped<ICampaignDefWithMemberShipTypeService, CampaignDefWithMemberShipTypeManager>();
            services.AddScoped<IMemberShipTypesWithPaymentChanelsService, MemberShipTypesWithPaymentChanelsManager>();
            services.AddScoped<ICampaignDefWithCampaignPropertiesDefService, CampaignDefWithCampaignPropertiesDefManager>();
            services.AddScoped<IMemberShipTypeWithCustomersPaymentChanelService, MemberShipTypeWithCustomersPaymentChanelManager>();



            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<INewsAndAnnouncementService, NewsAndAnnouncementManager>();


            services.AddScoped<IRvcMenuItemDefService, RvcMenuItemDefManager>();
            services.AddScoped<IRvcOptionsRightService, RvcOptionsRightManager>();
            services.AddScoped<IRvcMenuItemPriceService, RvcMenuItemPriceManager>();
            services.AddScoped<IMenuItemBarcodeDefService, MenuItemBarcodeDefManager>();
            services.AddScoped<ISluDefService, SluDefManager>();
            services.AddScoped<Islu_Rvc_RelationService, slu_Rvc_RelationManager>();
            services.AddScoped<ISluDefWithLanguageRepository, SluDefWithLanguageRepository>();
            services.AddScoped<IRvcMenuItemDefWithLanguageRepository, RvcMenuItemDefWithLanguageRepository>();

            #endregion

            #region Repository section
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IActiveProfileRepository, ActiveProfileRepository>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
            services.AddScoped<IProducerAgreementWithProductRepository, ProducerAgreementWithProductRepository>();
            services.AddScoped<IAttributeStaticRepository, AttributeStaticRepository>();
            services.AddScoped<IAttributeStaticValueRepository, AttributeStaticValueRepository>();
            services.AddScoped<IAvatarsRepository, AvatarsRepository>();
            services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
            services.AddScoped<IBugTrackDetailRepository, BugTrackDetailRepository>();
            services.AddScoped<ICampaignDefWithCouponRepository, CampaignDefWithCouponRepository>();
            services.AddScoped<ICampaignDefWithMemberShipTypePricePlaneRepository, CampaignDefWithMemberShipTypePricePlaneRepository>();
            services.AddScoped<ICampaignPropertiesDefRepository, CampaignPropertiesDefRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<ICancelReasonRepository, CancelReasonRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICustomerFovoriListRepository, CustomerFovoriListRepository>();
            services.AddScoped<ICustomerIdentitysRepository, CustomerIdentitysRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerNotificationLogsRepository, CustomerNotificationLogsRepository>();
            services.AddScoped<ICustomerRatingsRepository, CustomerRatingsRepository>();
            services.AddScoped<ICustomerTrackingTypeRepository, CustomerTrackingTypeRepository>();
            services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
            services.AddScoped<IDocumentsRepository, DocumentsRepository>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            services.AddScoped<IFrequentlyAskedQuestionsRepository, FrequentlyAskedQuestionsRepository>();
            services.AddScoped<IIntegrationPropertiesRepository, IntegrationPropertiesRepository>();
            services.AddScoped<IIntegrationRepository, IntegrationRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IMediaTypesRepository, MediaTypesRepository>();
            services.AddScoped<IMemberShipPaymentPlanWithPaymentChannelRepository, MemberShipPaymentPlanWithPaymentChannelRepository>();
            services.AddScoped<IMembershipPropertiesRepository, MembershipPropertiesRepository>();
            services.AddScoped<IMemberShipTypeRepository, MemberShipTypeRepository>();
            services.AddScoped<IMembershipTypePricePlaneRepository, MembershipTypePricePlaneRepository>();
            services.AddScoped<IMemberShipTypePropertiesTypeRepository, MemberShipTypePropertiesTypeRepository>();
            services.AddScoped<IMemberShipTypeWithCustomerRepository, MemberShipTypeWithCustomerRepository>();
            services.AddScoped<IMemberShipTypeWithCustomersProfilesRepository, MemberShipTypeWithCustomersProfilesRepository>();
            services.AddScoped<IMemberShipTypeWithPropertiesRepository, MemberShipTypeWithPropertiesRepository>();
            services.AddScoped<IMemberShipWithCampaignDefCouponRepository, MemberShipWithCampaignDefCouponRepository>();
            services.AddScoped<IMemberShipWithCancelReasonRepository, MemberShipWithCancelReasonRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IPaymentPeriodDefRepository, PaymentPeriodDefRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
            services.AddScoped<IPlayListRepository, PlayListRepository>();
            services.AddScoped<IPlayListDetailRepository, PlayListDetailRepository>();
            services.AddScoped<IProducersRepository, ProducersRepository>();
            services.AddScoped<IProducerTypeRepository, ProducerTypeRepository>();
            services.AddScoped<IProducerWithProduserTypeRepository, ProducerWithProduserTypeRepository>();
            services.AddScoped<IProductImagesRepository, ProductImagesRepository>();
            services.AddScoped<IProductWithAttributeStaticValueRepository, ProductWithAttributeStaticValueRepository>();
            services.AddScoped<IProductWithCategoryRepository, ProductWithCategoryRepository>();
            services.AddScoped<IProductWithProducersRepository, ProductWithProducersRepository>();
            services.AddScoped<IProtoectInformationRepository, ProtoectInformationRepository>();
            services.AddScoped<ISalesItemsRepository, SalesItemsRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserProtoectInformationRepository, UserProtoectInformationRepository>();
            services.AddScoped<IValueTypesRepository, ValueTypesRepository>();
            services.AddScoped<IVisitorCommentsRepository, VisitorCommentsRepository>();
            services.AddScoped<IMemberShipTypeWithCountryRepository, MemberShipTypeWithCountryRepository>();
            services.AddScoped<ICampaignDefWithMemberShipTypeRepository, CampaignDefWithMemberShipTypeRepository>();
            services.AddScoped<ICampaignDefWithCampaignPropertiesDefRepository, CampaignDefWithCampaignPropertiesDefRepository>();
            services.AddScoped<IMemberShipTypesWithPaymentChanelsRepository, MemberShipTypesWithPaymentChanelsRepository>();
            services.AddScoped<IMemberShipTypeWithCustomersPaymentChanelRepository, MemberShipTypeWithCustomersPaymentChanelRepository>();

            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<INewsAndAnnouncementRepository, NewsAndAnnouncementRepository>();


            services.AddScoped<IRvcMenuItemDefRepository, RvcMenuItemsDefRepository>();
            services.AddScoped<IRvcOptionsRightRepository, RvcOptionRightRepository>();
            services.AddScoped<IRvcMenuItemPriceRepository, RvcMenuItemPriceRepository>();
            services.AddScoped<IMenuItemBarcodeDefRepository, MenuItemBarcodeDefRepository>();
            services.AddScoped<ISluDefRepository, SluDefRepository>();
            services.AddScoped<IRvcMenuItemPriceRepository, RvcMenuItemPriceRepository>();
            services.AddScoped<Islu_Rvc_RelationRepository, slu_Rvc_RelationRepository>();

            #endregion

            #region Unit Of Works
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Token Service

            #endregion

            #region CORS Settings

            #endregion




            var appSettings2 = Configuration.GetSection("AppSettings");
            services.Configure<AppleSettings>(appSettings2);
            services.AddAuthentication()
                .AddGoogle(x =>
                {
                    //x.ClientId = "762785292050-kjhrsl8jkun73ucbigne8vj7mgcsc1ut.apps.googleusercontent.com";
                    //x.ClientSecret = "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";
                    x.ClientId = "762785292050-kjhrsl8jkun73ucbigne8vj7mgcsc1ut.apps.googleusercontent.com";
                    x.ClientSecret = "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";
                }).AddFacebook(x =>
                {
                    x.AppId = "311718307442051";
                    x.AppSecret = "c7b9335238773e55a8b4bc746129c769";
                    //x.AppId = "238098111558335";
                    //x.AppSecret = "e9ae0b0497dd69ff3bac8b000d5b1bbe";
                });


            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);
            services.Configure<FormOptions>(x => x.ValueCountLimit = 10000000);


            services.AddIdentity<AppUser, IdentityRole>(
                opt =>
                {
                    opt.Password.RequireDigit = true;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                }

                ).AddEntityFrameworkStores<ProjeDBContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/AdminLogin");
                opt.Cookie.Name = "Quki";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Lax; // google - facebook giriþlerinde Strict olduðundan dolayý giriþ yapmýyordu lax yapýldý ARAÞTIR
                //opt.ExpireTimeSpan = TimeSpan.FromSeconds(500);// dakika boyunca 
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);//cookie oturum süresini 60dk ayarladým

            });

            //services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; });
            //services.AddSingleton<Interfaces.IEmailSender, MailKitEmailSender>();
            //services.Configure<MailKitEmailSenderOptions>(options =>
            //{
            //    options.Host_Address = "smtp.gmail.com";
            //    options.Host_Port = 587;
            //    options.Host_Username = "BMS";
            //    options.Host_Password = "zuposbms2021";
            //    options.Sender_EMail = "zupos@bmsproje.com";
            //    options.Sender_Name = "BMSPROJE";
            //});

            //var mailOption = _config.GetSection("Email").Get<MailKitOptions>();
            //services.AddMailKit(config => config.UseMailKit(mailOption));
            services.AddControllersWithViews();// MVC eklemek Ýçin
            //services.AddCors

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseStatusCodePagesWithReExecute("/error/{0}");
            //}
            app.UseExceptionHandler("/error");

            app.UseXMLSitemap(env.ContentRootPath);

            var supportedCultures = new[]
           {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
                new CultureInfo("de-DE")

            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseRouting();
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path.StartsWithSegments("/robots.txt"))
            //    {
            //        var robotsTxtPath = Path.Combine(env.ContentRootPath, "robots.txt");
            //        string output = "User-agent: *  \nDisallow: \n\nSitemap: https://www.Quki.com/sitemap.xml";
            //        if (File.Exists(robotsTxtPath))
            //        {
            //            output = await File.ReadAllTextAsync(robotsTxtPath);
            //        }
            //        context.Response.ContentType = "text/plain";
            //        await context.Response.WriteAsync(output);
            //    }
            //    else await next();
            //});

            app.UseStaticFiles();
            app.UseRouting();


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>

            {

                //*check the website-content and all elements like images
                string sHost = context.Request.Host.HasValue == true ? context.Request.Host.Value : "";  //domain without :80 port .ToString();

                sHost = sHost.ToLower();

                string sPath = context.Request.Path.HasValue == true ? context.Request.Path.Value : "";

                string sQuerystring = context.Request.QueryString.HasValue == true ? context.Request.QueryString.Value : "";



                //----< check https >----

                // check if the request is *not* using the HTTPS scheme


                if (!context.Request.IsHttps)

                {

                    //--< is http >--

                    string new_https_Url = "https://" + sHost;

                    if (sPath != "")

                    {

                        new_https_Url = new_https_Url + sPath;

                    }

                    if (sQuerystring != "")

                    {

                        new_https_Url = new_https_Url + sQuerystring;

                    }
                }

                //--</ is http >--



                //----</ check https >----



                ////----< check www > ----
                if (!sPath.Contains("api"))
                {


                    if (sHost.Contains("www."))

                    {

                        //--< is www. >--

                        string new_Url_without_www = "https://" + sHost;

                        if (sPath != "")

                        {

                            new_Url_without_www = new_Url_without_www + sPath;

                        }

                        if (sQuerystring != "")

                        {

                            new_Url_without_www = new_Url_without_www + sQuerystring;

                        }

                        context.Response.Redirect(new_Url_without_www, true);



                        return;

                        //--</ is http >--

                    }

                    //----</ check www >----

                }

                //also check images inside the content

                await next();


            });

            // ----< redirect http to https > ---


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{Controller=Home}/{Action=Index}/{id?}");
                //endpoints.MapControllerRoute("Default5", "{controller=DocumentPage}/{action=GetDocument}/{name?}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{Controller=akyol}/{Action=firin}");
                endpoints.MapControllerRoute("dMenu", "mobile-menu", new { controller = "Product", action = "Index" });



            });



        }


    }
}
