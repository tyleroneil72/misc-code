# No Doze

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
![Bash](https://img.shields.io/badge/Shell_Script-121011?style=for-the-badge&logo=gnu-bash&logoColor=white)

## Description

As a primary Mac user, I've often faced the challenge of using my MacBook with an external monitor while keeping it closed and unplugged, to help preserve battery health. Apple's default settings, however, cause the external display to turn off when the MacBook is closed and not charging. While there are various apps available to address this issue, a simple solution exists right within the MacBook's Terminal. Just a few commands can effectively resolve this problem.

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

If No Doze is on, the hibernatemode will be 0, else it will be what you set it to (Default 3)

```bash
# Run this command to check what your hibernation mode currently is
pmset -g | grep hibernatemode
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contact

For any inquiries or questions, you can reach me at tyleroneildev@gmail.com
or on my linkedin at https://ca.linkedin.com/in/tyler-oneil-dev
