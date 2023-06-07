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


        public async Task testBooleanType()
        {

            var arguments = new List<ICadence>
            {
                new CadenceBool(true)
            };

            var script = @"
                    pub fun main(value: Bool) : Bool{
                        return value
                    }
                ";

            var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
            {
                Script = script,
                Arguments = arguments
            });

            CadenceDecoding cadenceEncoding = new CadenceDecoding();
            var value = cadenceEncoding.decode(result);
            Console.WriteLine($"Bool: {value}");

        }

        public async Task testIntType()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int,"-38")
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
            Console.WriteLine($"Int: {value}");

        }

        public async Task testUIntType()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt,"38")
            };

            var script = @"
                    pub fun main(num: UInt) : UInt{
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
            Console.WriteLine($"UInt: {value}");

        }

        public async Task testInt8Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int8,"-128")
            };

            var script = @"
                    pub fun main(num: Int8) : Int8{
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
            Console.WriteLine($"Int8: {value}");

        }

        public async Task testUInt8Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt8,"255")
            };

            var script = @"
                    pub fun main(num: UInt8) : UInt8{
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
            Console.WriteLine($"UInt8: {value}");

        }

        public async Task testInt16Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int16,"-32768")
            };

            var script = @"
                    pub fun main(num: Int16) : Int16{
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
            Console.WriteLine($"Int16: {value}");

        }

        public async Task testUInt16Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt16,"65535")
            };

            var script = @"
                    pub fun main(num: UInt16) : UInt16{
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
            Console.WriteLine($"UInt16: {value}");

        }

        public async Task testInt32Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int32,"-2147483648")
            };

            var script = @"
                    pub fun main(num: Int32) : Int32{
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
            Console.WriteLine($"Int32: {value}");

        }

        public async Task testUInt32Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt32,"4294967295")
            };

            var script = @"
                    pub fun main(num: UInt32) : UInt32{
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
            Console.WriteLine($"UInt32: {value}");

        }

        public async Task testInt64Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int64,"-9223372036854775808")
            };

            var script = @"
                    pub fun main(num: Int64) : Int64{
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
            Console.WriteLine($"Int64: {value}");

        }

        public async Task testUInt64Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt64,"18446744073709551615")
            };

            var script = @"
                    pub fun main(num: UInt64) : UInt64{
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
            Console.WriteLine($"UInt64: {value}");

        }

        public async Task testInt128Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int128,"-9223372036854775808")
            };

            var script = @"
                    pub fun main(num: Int128) : Int128{
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
            Console.WriteLine($"Int128: {value}");

        }

        public async Task testUInt128Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt128,"18446744073709551615")
            };

            var script = @"
                    pub fun main(num: UInt128) : UInt128{
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
            Console.WriteLine($"UInt128: {value}");

        }

        public async Task testInt256Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Int256,"-9223372036854775808")
            };

            var script = @"
                    pub fun main(num: Int256) : Int256{
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
            Console.WriteLine($"Int256: {value}");

        }

        public async Task testUInt256Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UInt256,"18446744073709551615")
            };

            var script = @"
                    pub fun main(num: UInt256) : UInt256{
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
            Console.WriteLine($"UInt256: {value}");

        }

        public async Task testWord8Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Word8,"255")
            };

            var script = @"
                    pub fun main(num: Word8) : Word8{
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
            Console.WriteLine($"Word8: {value}");

        }

        public async Task testWord16Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Word16,"65535")
            };

            var script = @"
                    pub fun main(num: Word16) : Word16{
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
            Console.WriteLine($"Word16: {value}");

        }

        public async Task testWord32Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Word32,"4294967295")
            };

            var script = @"
                    pub fun main(num: Word32) : Word32{
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
            Console.WriteLine($"Word32: {value}");

        }

        public async Task testWord64Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Word64,"18446744073709551615")
            };

            var script = @"
                    pub fun main(num: Word64) : Word64{
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
            Console.WriteLine($"Word64: {value}");

        }

        //Currently not supported by flow-dotnet-sdk
        // public async Task testWord128Type()
        // {

        //     var arguments = new List<ICadence>
        //     {
        //         new CadenceNumber(CadenceNumberType.Word128,"340282366920938463463374607431768211455")
        //     };

        //     var script = @"
        //             pub fun main(num: Word128) : Word128{
        //                 return num
        //             }
        //         ";

        //     var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
        //     {
        //         Script = script,
        //         Arguments = arguments
        //     });

        //     CadenceDecoding cadenceEncoding = new CadenceDecoding();
        //     var value = cadenceEncoding.decode(result);
        //     Console.WriteLine($"Word128: {value}");

        // }


        // //Currently not supported by flow-dotnet-sdk
        // public async Task testWord256Type()
        // {

        //     var arguments = new List<ICadence>
        //     {
        //         new CadenceNumber(CadenceNumberType.Word256,"115792089237316195423570985008687907853269984665640564039457584007913129639935")
        //     };

        //     var script = @"
        //             pub fun main(num: Word256) : Word256{
        //                 return num
        //             }
        //         ";

        //     var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
        //     {
        //         Script = script,
        //         Arguments = arguments
        //     });

        //     CadenceDecoding cadenceEncoding = new CadenceDecoding();
        //     var value = cadenceEncoding.decode(result);
        //     Console.WriteLine($"Word256: {value}");

        // }

        public async Task testFix64Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.Fix64,"-92233720368.54775808")
            };

            var script = @"
                    pub fun main(num: Fix64) : Fix64{
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
            Console.WriteLine($"Fix64: {value}");

        }

        public async Task testUFix64Type()
        {

            var arguments = new List<ICadence>
            {
                new CadenceNumber(CadenceNumberType.UFix64,"184467440737.09551615")
            };

            var script = @"
                    pub fun main(num: UFix64) : UFix64{
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
            Console.WriteLine($"UFix64: {value}");

        }

        public async Task testAddressType()
        {

            var arguments = new List<ICadence>
            {
                new CadenceAddress("0xa725f0c0b625480e")
            };

            var script = @"
                    pub fun main(value: Address) : Address{
                        return value
                    }
                ";

            var result = await _flowClient.ExecuteScriptAtLatestBlockAsync(new FlowScript
            {
                Script = script,
                Arguments = arguments
            });

            CadenceDecoding cadenceEncoding = new CadenceDecoding();
            var value = cadenceEncoding.decode(result);
            Console.WriteLine($"Address: {value}");

        }

    }
}