// See https://aka.ms/new-console-template for more information
using System;
using Flow.Net.Sdk.Core.Client;
using Flow.Net.Sdk.Core.Models;
using Flow.Net.Sdk.Client.Http;
using Decoding;

using Flow.Net.Sdk.Core.Cadence;


namespace ScriptTesting
{
    public class FlowScriptTesting
    {
        FlowHttpClient _flowClient = new FlowHttpClient(new HttpClient(), new FlowClientOptions { ServerUrl = "https://rest-testnet.onflow.org/v1/" });
        // public async Task testIntType()
        // {

        //     var arguments = new List<ICadence>
        //     {
        //         new CadenceNumber(CadenceNumberType.UInt64,"38"),
        //         new CadenceNumber(CadenceNumberType.UInt64,"77"),
        //         new CadenceNumber(CadenceNumberType.UInt64,"73"),
        //         new CadenceAddress("0xa725f0c0b625480e"),

        //     };

        //     var script1 = @"
        //             import BloomlyDrop from 0xee6decf3519d7d3b
        //             pub fun main(brandId:UInt64,dropId: UInt64, assetId:UInt64, userAddress: Address): {String: UInt64?} {
        //                 var userClaimDetails: {String: UInt64?} = {" + "\"ItemsClaimed\" : nil,\"TotalLimit\" : nil} \n" +
        //                 @"let dropDetails = BloomlyDrop.getDropById(dropId: dropId, brandId: brandId)
        //                 if(dropDetails != nil){ 
        //                     let allDropAssets = dropDetails!.getAsset();
        //                     if (allDropAssets[assetId] !=nil){
        //                         let userLimit = allDropAssets[assetId]?.limit
        //                         userClaimDetails[" + "\"TotalLimit\"] = userLimit \n" +
        //                       @"userClaimDetails[" + "\"ItemsClaimed\"] = 0 \n" +
        //                       @"let userAllClaimedBrands = BloomlyDrop.getAddressClaimed(user: userAddress);
        //                         let allClaimedDrops = userAllClaimedBrands[brandId];

        //                         if(allClaimedDrops != nil){
        //                             let userClaimAmount = allClaimedDrops![dropId] ?? 0;
        //                             userClaimDetails[" + "\"ItemsClaimed\"] = userClaimAmount;" +
        //                        @"}
        //                     }
        //                 }
        //                 return userClaimDetails;
        //             }
        //         ";

        //     var script2 = @"
        //             import NonFungibleToken from 0x631e88ae7f1d7c20
        //             import BloomlyNFT from 0xee6decf3519d7d3b

        //             pub fun main(Owner: Address) : [UInt64]{
        //                 let account = getAccount(Owner)
        //                 let acct1Capability =  account.getCapability(BloomlyNFT.CollectionPublicPath)
        //                                         .borrow<&{BloomlyNFT.BloomlyNFTCollectionPublic}>()
        //                                         ??panic(" + "\" sham \" ) \n" +
        //                 @"return acct1Capability.getIDs()
        //             }            
        //         ";

        //     var arguments2 = new List<ICadence>
        //     {
        //         new CadenceAddress("0xa725f0c0b625480e"),

        //     };

        //     var script3 = @"
        //             import NonFungibleToken from 0x631e88ae7f1d7c20
        //             import BloomlyNFT from 0xee6decf3519d7d3b
        //             import MetadataViews from 0x631e88ae7f1d7c20

        //             pub fun main(address: Address): &NonFungibleToken.NFT {
        //                 let account = getAccount(address)

        //                 let collection = account.getCapability(BloomlyNFT.CollectionPublicPath)
        //                                     .borrow<&{BloomlyNFT.BloomlyNFTCollectionPublic}>()
        //                                     ??panic(" + "\" sham \" ) \n" +

        //                 @"
        //                 let nftId = collection.getIDs()[0]
        //                 let nft = collection.borrowNFT(id: nftId)!
        //                 return nft
        //             }
        //         ";


        //     var script4 = @"
        //             import BloomlyNFT from 0xee6decf3519d7d3b

        //             pub fun main(): BloomlyNFT.Brand {
        //                 return BloomlyNFT.getBrandById(brandId: 5)
        //             }
        //         ";

        //     var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
        //     {
        //         Script = script3,
        //         Arguments = arguments2
        //     });

        //     CadenceEncoding cadenceEncoding = new CadenceEncoding();
        //     var value = cadenceEncoding.encode(result);
        //     if (value != null)
        //         Console.WriteLine(value);
        //     else
        //         Console.WriteLine("Null");

        //     // //for dictionary
        //     // foreach (var v in value)
        //     // {
        //     //     Console.WriteLine($"{v.Key}");
        //     //     // foreach (var v2 in v.Value)
        //     //     // {
        //     //     //     Console.WriteLine($"{v2.Key}: {v2.Value}");
        //     //     // }
        //     // }

        //     //for array
        //     foreach (var v in value)
        //     {
        //         Console.WriteLine($"{v}");
        //     }

        // }


        public async Task testIntType()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int,"38")
            };

            var script = @"
                    pub fun main(num: Int) : Int{
                        return num
                    }
                ";

            var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
            {
                Script = script,
                Arguments = arguments
            });

            CadenceDecoding cadenceEncoding = new CadenceDecoding();
            var value = cadenceEncoding.decode(result);
            Console.WriteLine(value);

        }
    }
}