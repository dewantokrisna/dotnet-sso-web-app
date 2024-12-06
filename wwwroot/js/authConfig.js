 
const msalConfig = {
  auth: {
    clientId: "<Client_ID>",
    authority: "https://login.microsoftonline.com/<Tenant_ID>",
    redirectUri: "https://localhost:<Port>/",
  },
  cache: {
    cacheLocation: "sessionStorage", 
    storeAuthStateInCookie: false, 
  }
};  

const loginRequest = {
  scopes: ["openid"]
};
  
