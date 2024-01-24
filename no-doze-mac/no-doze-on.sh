# Turn on No Doze

# Use this to check the hibernation mode of the system
# pmset -g | grep hibernatemode

sudo pmset -a sleep 0
sudo pmset -a hibernatemode 0
sudo pmset -a disablesleep 1