# Turn off No Doze

sudo pmset -a sleep 10
# Use the original hibernation mode (3 on macbook)
sudo pmset -a hibernatemode 3
sudo pmset -a disablesleep 0

echo "No Doze: \033[91mOFF\033[91m"