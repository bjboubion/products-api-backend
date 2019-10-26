using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using products_api.Products.API.Interfaces;
using products_api.Products.Infrastructure.Context;
using products_api.Products.API.ViewModel;
using products_api.Products.Domain.Models;

namespace products_api.Products.Tests.UnitTests
{
    [TestFixture]
    public class KitServiceTest
    {
        Mock<IKitService> mockServices = new Mock<IKitService>(MockBehavior.Strict);
        DbKit exampleKit1;
        DbKit exampleKit2;
        DbKit exampleKit3;
        List<DbKit> kitList;
        List<KitViewModel> viewList;
        IKitService kitService;

        [OneTimeSetUp]
        [Obsolete]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<KitProfile>();
            });
        }

        [SetUp]
        public void Setup()
        {
            // Entities
            exampleKit1 = new DbKit
            {
                Id = "D3062",
                Name = "Urine Collection Kit",
                Sku = "D3062",
                Price = 118.0,
                ZREPrice = 118.0,
                Option = "10 Pack",
                WebActive = true,
                ImageUrl = "https://files.zymoresearch.com/product-images/D3062_Urine-Collection-Kit-with-Urine-Conditioning-Buffer.png",
                HighlightA = "Effectively preserves DNA and RNA in urine at ambient temperatures",
                HighlightB = "Facilitates pelleting of urine nucleic acids from large volume urine samples for nucleic acids purification",
                HighlightC = "Microbial inactivation",
                Description = "The Urine Collection Kit w/ Urine Conditioning Buffer (UCB) ensures nucleic acid stability in urine during sample storage/transport at ambient temperatures.",
                ShortDescription = "Kit for the collection and preservation of DNA and RNA in urine.",
                ProductType = ProductType.kit,
                ManufacturingOptions = new DbManufacturingOptions
                {
                    Weight = 1.35,
                    Height = 0,
                    Width = 0,
                    Length = 3.5
                },
                ShippingOptions = new DbShippingOptions
                {
                    HazardShipping = false,
                    ColdShipping = false,
                    TypeIceShipping = null,
                    ShippingTemp = 33
                },
                Documents = new DbProductDocuments
                {
                    Protocol = "https://files.zymoresearch.com/protocols/_d4301_d4305_zymobiomics_dna_microprep_kit.pdf",
                    Datasheet = "https://files.zymoresearch.com/datasheets/ds1704_zymobiomics_dna_extraction_data_sheet.pdf",
                    SDS = "https://files.zymoresearch.com/sds/_d4301_zymobiomics_dna_microprep_kit.pdf"
                },
                Components = new List<string>
                {
                    "D3062-1",
                    "D3061-1-8",
                    "D3061-1-140"
                },
                ModifiedOn = DateTime.Parse("019-04-29T22:23:58.657Z"),
                CreatedOn = DateTime.Parse("2019-04-29T22:23:58.657Z")
            };
            exampleKit2 = new DbKit
            {
                Id = "R1002",
                Name = "YeaStar RNA Kit",
                Sku = "R1002",
                Price = 148.0,
                ZREPrice = 148.0,
                Option = "40 Preps",
                WebActive = true,
                ImageUrl = "https://files.zymoresearch.com/product-images/R1002_YeaStar-RNA-Kit.jpg",
                HighlightA = "<b>Simple:</b> Fast spin-column procedure yields pure yeast RNA without using glass beads or phenol.",
                HighlightB = "<b>Versatile:</b> Efficient RNA isolation from a broad spectrum of fungal species susceptible to Zymolyase.",
                HighlightC = "<b>High-Quality:</b> Isolated RNA is suitable for use in RT-PCR, Northern blotting, etc.",
                Description = "The YeaStar RNA Kit provides all the necessary reagents for RNA isolation from a broad spectrum of fungi including: <i>Aspergillus fumigatus</i>, <i>Aspergillus nidulans</i>, <i>Aspergillus nivens var. aureus</i>, <i>Candida albicans/<i>, Pichia pastoris</i>, <i>Saccharomyces cerevisiae</i>, <i>Schizosaccharomyces pombe</i>. Generally, the kit can be used for the purification of high-quality, total RNA from any fungus that can be lysed by yeast lytic enzyme. The kit facilitates the purification of 10-25 &micro;g of total RNA from 1-1.5 ml of cultured cells using innovative Zymo-Spin column technology.",
                ShortDescription = "Simple spin-column solution for isolating RNA from yeast using Zymolyase.",
                ProductType = ProductType.kit,
                ManufacturingOptions = new DbManufacturingOptions
                {
                    Weight = 0.8,
                    Height = 0,
                    Width = 0,
                    Length = 7
                },
                ShippingOptions = new DbShippingOptions
                {
                    HazardShipping = false,
                    ColdShipping = false,
                    TypeIceShipping = null,
                    ShippingTemp = 23
                },
                Documents = new DbProductDocuments
                {
                    Protocol = "https://files.zymoresearch.com/protocols/_d4301_d4305_zymobiomics_dna_microprep_kit.pdf",
                    Datasheet = "https://files.zymoresearch.com/datasheets/ds1704_zymobiomics_dna_extraction_data_sheet.pdf",
                    SDS = "https://files.zymoresearch.com/sds/_d4301_zymobiomics_dna_microprep_kit.pdf"
                },
                Components = new List<string>
                {
                   "W1001-6",
                   "R1001-1",
                   "R1001-2",
                   "R1003-3-6",
                   "C1001-50",
                   "C1006-50-G" 
                },
                ModifiedOn = DateTime.Parse("2019-03-28T16:27:46.807Z"),
                CreatedOn = DateTime.Parse("2019-03-28T16:27:46.807Z")
            };
            exampleKit3 = new DbKit
            {
                Id = "T2001",
                Name = "",
                Sku = "",
                Price = 104,
                ZREPrice = 104,
                Option = "",
                WebActive = true,
                ImageUrl = "",
                HighlightA = "",
                HighlightB = "",
                HighlightC = "",
                Description = "",
                ShortDescription = "",
                ProductType = ProductType.kit,
                ManufacturingOptions = new DbManufacturingOptions
                {
                    Weight = 0.5,
                    Height = 0,
                    Width = 0,
                    Length = 4.3
                },
                ShippingOptions = new DbShippingOptions
                {
                    HazardShipping = false,
                    ColdShipping = false,
                    TypeIceShipping = null,
                    ShippingTemp = 23
                },
                Documents = new DbProductDocuments
                {
                    Protocol = "https://files.zymoresearch.com/protocols/_d4301_d4305_zymobiomics_dna_microprep_kit.pdf",
                    Datasheet = "https://files.zymoresearch.com/datasheets/ds1704_zymobiomics_dna_extraction_data_sheet.pdf",
                    SDS = "https://files.zymoresearch.com/sds/_d4301_zymobiomics_dna_microprep_kit.pdf"
                },
                Components = new List<string>
                {
                    "T2002",
                    "T2003",
                    "T2004"
                },
                ModifiedOn = DateTime.Parse("2019-01-30T22:47:54.35Z"),
                CreatedOn = DateTime.Parse("2019-01-30T22:47:54.35Z")
            };

            kitList = new List<DbKit> { exampleKit1, exampleKit2, exampleKit3 };
            viewList = Mapper.Map<List<KitViewModel>>(kitList);

            // Service Interface Implementation
            mockServices.Setup(s => s.GetAll()).ReturnsAsync(viewList);

            mockServices.Setup(s => s.GetBySku(It.IsAny<string>())).ReturnsAsync(
                (string sku) =>
                {
                    DbKit model = kitList.Where(m => m.Id == sku).FirstOrDefault();
                    KitViewModel newModel = null;

                    if (model != null)
                    {
                        newModel = Mapper.Map<KitViewModel>(model);
                    }

                    return newModel;
                }
            );

            // mockServices.Setup(s => s.GetKitComponents(It.IsAny<string>())).ReturnsAsync(
            //      (string kitSku) => 
            //     {
            //         DbKit model = kitList.Where(m => m.Id == kitSku).FirstOrDefault();
            //         DbKit newModel = null;

            //         List<DbVariant> componentList = new List<DbVariant>();

            //         if (model != null)
            //         {
            //             newModel = new DbKit
            //             {
            //                 Id = model.Id,
            //                 Name = model.Name,
            //                 Components = model.Components
            //             };
            //         }

            //         foreach(var sku in newModel.Components)
            //         {
            //             // Get components 
            //             // Currently, components have not been created
                        
            //         }

            //         return componentList;
            //     }
            // );

            // THIS IS ESSENTIAL TO USE THE MOCK SERVICES CREATED ABOVE
            // SINCE WE USE KITSERVICE, WILL RETURN NULL EXCEPTION
            kitService = mockServices.Object;
        }

        [Test]
        public async Task KitService_GetAllKits_ReturnsListOfDomainKits()
        {
            // Arrange
            // Nothing to arrange

            // Act
            var repoKitList = await kitService.GetAll();

            // Assert
            Assert.That(repoKitList, Is.InstanceOf<List<KitViewModel>>());
            Assert.That(repoKitList, Is.Not.Null);
        }

        [Test]
        public async Task KitService_GetKitBySku_ReturnsDomainKit()
        {
            // Arrange
            var sku = "D3062";

            // Act
            var kit = await kitService.GetBySku(sku);

            // Assert
            Assert.That(kit, Is.InstanceOf<KitViewModel>());
        }
    }
}