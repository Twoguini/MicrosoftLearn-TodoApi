gnome-terminal -- bash -c "cd ./Api-Task; dotnet run; exec bash"

sleep 5

gnome-terminal -- bash -c "cd ./ApiTesting; dotnet run; exec bash"