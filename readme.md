```bash
# clone project api
$ git clone https://github.com/andew95/stock-api-demo.git

# update database structure
$ dotnet -ef database update

# clone project fontend
$ git clone https://github.com/andew95/stock-fontend-demo.git

# config api cors Program.cs
# update .WithOrigins("{your_fontend_url}")
```
