// my_script.js
import { ThirdwebSDK } from "@thirdweb-dev/sdk";

// instantiate the SDK in read-only mode (our example is running on `polygon` here)
// all major chains and testnets are supported (e.g. `mainnet`, 'optimism`, 'arbitrum', 'polygon', `goerli`, 'mumbai', etc.)
const sdk = new ThirdwebSDK("polygon");

// access your deployed contracts
const contract = await sdk.getContract("0x...");

// Read data using direct calls to your contract
const myData = await contract.call("myFunction");

// Or Using the extensions API matching to your contract extensions
const allNFTs = await contract.erc721.getAll();
const tokenSupply = await contract.erc20.totalSupply();