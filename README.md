# Template.Core
一个基于vue的前后端模板工程，涉及到一点AI

# webapi部署

nohup dotnet XXwebapi.dll  --urls="http://*:5601"  --ip="127.0.0.1" --port="5601" &   webapi的部署命令

# webUI部署
nohup dotnet XXwebUI.dll  --urls="http://*:8001"  --ip="127.0.0.1" --port="8001" &    webui的部署命令

# 注释
mvc创建一个aspnetcore的mvc站点只做页面展示，类似node服务器
服务的调用使用vue通过ajax请求webapi站点
