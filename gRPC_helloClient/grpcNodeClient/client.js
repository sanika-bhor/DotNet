const grpc=require("@grpc/grpc-js");
const protoLoader=require("@grpc/proto-loader");
const PROTO_PATH= __dirname+'/greet.proto';

const packageDefinition=protoLoader.loadSync(PROTO_PATH,
    {
        keepCase:true,
        longs:String,
        enums:String,
        defaults:true,
        oneofs:true
    }
);

const greetProto=grpc.loadPackageDefinition(packageDefinition).greet;

const client=new greetProto.Greeter('localhost:5224',grpc.credentials.createInsecure());

client.SayHello({ name: "Sanika" }, (err, response) => {
  if (err) {
    console.error("Error", err);
    return;
  }

  console.log("Greeting From Server: "+response.message);
});