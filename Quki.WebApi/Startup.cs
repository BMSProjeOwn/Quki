using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using Quki.Bll;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Dal.Concrete.Entityframework.UnitOfWork;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Repo-kod opt.
            //unitofworks--pattern--transaction yönetimini
            #region JwtTokenService
            services
                .AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;

                    cfg.Events = new JwtBearerEvents();
                    cfg.Events.OnChallenge = context =>
                    {
                        // Skip the default logic.
                        context.HandleResponse();

                        var payload = new JObject
                        {
                            ["error"] = context.Error,
                            ["error_description"] = context.ErrorDescription,
                            ["error_uri"] = context.ErrorUri
                        };

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;

                        return context.Response.WriteAsync(payload.ToString());
                    };
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    };
                });


            services.Configure<List<ClientModel>>(Configuration.GetSection("Clients"));

            #endregion

            //cache layer--redis nosql

            //IIS--> mssql--
            //loadbalancer--
            //muh  123  A B C(X)

            //node.js--.net 5 hemen hemen 2 katı

            //10 bin kişi A  10bin B 10 bin C---dikey büyüme

            //yatay büyüme

            //container teknolojileri--docker(docker file)--kubernates--bubernates classter


            services.AddControllers();
            services.AddDbContext<ProjeDBContext>();
            services.AddScoped<DbContext, ProjeDBContext>();

            #region Servis section
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IActiveProfileService, ActiveProfileManager>();
            services.AddScoped<IAgreementService, AgreementManager>();
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
            services.AddScoped<ICustomerService, CustomerManager>();
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
            services.AddScoped<ISalesService, SalesManager>();
            services.AddScoped<ITestService, TestManager>();
            services.AddScoped<IUserProfileService, UserProfileManager>();
            services.AddScoped<IUserProtoectInformationService, UserProtoectInformationManager>();
            services.AddScoped<IValueTypesService, ValueTypesManager>();
            services.AddScoped<IVisitorCommentService, VisitorCommentsManager>();
            services.AddScoped<IMemberShipTypeWithCountryService, MemberShipTypeWithCountryManager>();
            services.AddScoped<IPaymentChanelWithDeviceTypeService, PaymentChanelWithDeviceTypeManager>();
            services.AddScoped<IMemberShipTypeWithCustomersPaymentChanelService, MemberShipTypeWithCustomersPaymentChanelManager>();
            services.AddScoped<IDeviceTypeService, DeviceTypeManager>();
            services.AddScoped<ILogService, LogManager>();
            #endregion

            #region Repository section
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IActiveProfileRepository, ActiveProfileRepository>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
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
            services.AddScoped<IMemberShipTypeWithCustomersPaymentChanelRepository, MemberShipTypeWithCustomersPaymentChanelRepository>();
            services.AddScoped<IPaymentChanelWithDeviceTypeRepository, PaymentChanelWithDeviceTypeRepository>();
            services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            #endregion

            #region Unit Of Works
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Token Service

            #endregion

            #region CORS Settings

            #endregion

            services.AddAuthentication();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quki.WebApi", Version = "v1" });
            });

            services.AddIdentity<AppUser, IdentityRole>(
                opt =>
                {
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredLength = 1;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.SignIn.RequireConfirmedEmail = true;
                }

                ).AddEntityFrameworkStores<ProjeDBContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quki.WebApi v1")); ;
            }

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
