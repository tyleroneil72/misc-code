# DVD Screensaver

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
![Bash](https://img.shields.io/badge/Shell_Script-121011?style=for-the-badge&logo=gnu-bash&logoColor=white)

## Description

As a primary MacBook user I have always struggled with wanting to plug my MacBook to a monitor while it is closed while it is not connected to a power source to save battery health. Unfortunately Apple has made the default hibernation settings to shut off the external display if the computer is closed and not plugged in. There are many applications you can download, but this problem can be solved in just a few commands on the terminal.

## Installation

After cloning the repository add executing privileges

```bash
chmod +x no-doze-on.sh
chmod +x no-doze-off.sh
```

## Usage

```bash
# To turn it on
./no-doze-on.sh
# To turn it off
./no-doze-off.sh
```

## Note:

```bash
# Run this command to check what your hibernation mode currently is
pmset -g | grep hibernatemode
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contact

For any inquiries or questions, you can reach me at tyleroneildev@gmail.com
or on my linkedin at https://ca.linkedin.com/in/tyler-oneil-dev
