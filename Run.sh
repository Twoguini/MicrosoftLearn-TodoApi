chmod +x "$0"

gnome-terminal -- bash -c "cd ./Api-Task && dotnet run"

sleep 5

gnome-terminal -- bash -c "cd ./ApiTesting && dotnet run"