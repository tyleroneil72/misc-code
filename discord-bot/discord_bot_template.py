"""
Created by Tyler O'Neil
Version 1.0

This is a very simple template that can be fully customized for any 
specific bot feature using python. Useful for text bots.

For more info -> https://discord.com/developers/docs/intro
"""


import discord

client = discord.Client()

# Put the symbol you want to use here
YOUR_SYMBOL_HERE = ""
# Put your token here to connect to discord
YOUR_TOKEN_HERE = ""


@client.event
async def on_message(message) -> None:
    """
    This function will allow the bot to react to user inputs

    Message paramater: The message sent on a discord channel the bot
    has access to.

    Returns: None
    """

    # The bot does not reply to itself
    if message.author == client.user:
        return

    if message.content.startswith(YOUR_SYMBOL_HERE):

        # Customize the message the bot will send out
        msg = ""
        await message.channel.send(msg)


@client.event
async def on_member_join(member) -> None:
    """
    This function will send a custom message to a member who joins
    the server.

    Member Parameter: Discord member who joins server that the bot
    is also in.

    Returns: None
    """
    await member.create_dm()

    # Customize this to whatever you want it to say
    await member.dm_channel.send(f'Hi {member.name}')

# Add and customize functions as you see necessary to improve
# your bot :)


@client.event
async def on_ready() -> None:
    """
    This code will execute when the bot is ready.

    Returns: None
    """
    print("logged in as")
    print(client.user.name)
    print(client.user.id)
    print("-------")

client.run(YOUR_TOKEN_HERE)
