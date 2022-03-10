const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7455';

const context =  [
  "/api/boats",
  "/api/boats/create",
  "/api/boats/all",
  "/api/boats/delete",
  "/api/crew",
  "/api/crew/create",
  "/api/crew/all",
  "/api/crew/delete"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false
  });

  app.use(appProxy);
};
