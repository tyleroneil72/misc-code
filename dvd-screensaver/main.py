"""
Created by Tyler O'Neil
Version 1.0

For more info -> https://www.pygame.org/docs/
"""
import pygame

def game():
    """
    Simple DVD Screensaver made with pygame just for fun
    """
    pygame.init()

    SPEED = 1
    SCREEN_SIZE = (1000, 600)
    BLUE = pygame.image.load("images/blue.png")
    BLUE = pygame.transform.scale(BLUE, (200, 100))
    YELLOW = pygame.image.load("images/yellow.png")
    YELLOW = pygame.transform.scale(YELLOW, (200, 100))
    GREEN = pygame.image.load("images/green.png")
    GREEN = pygame.transform.scale(GREEN, (200, 100))
    PURPLE = pygame.image.load("images/purple.png")
    PURPLE = pygame.transform.scale(PURPLE, (200, 100))
    corner_score = 0
    font = pygame.font.Font('freesansbold.ttf', 32)
    screen = pygame.display.set_mode(SCREEN_SIZE)
    pygame.display.set_caption("Screensaver")
    ball = pygame.image.load("images/ball.png")
    ball = pygame.transform.scale(ball, (200, 100))
    ballrect = ball.get_rect()
    ballspeed = [SPEED, SPEED]
    X = 10
    Y = 10

    while True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                quit()

        ballrect = ballrect.move(ballspeed)
        if ballrect.left < 0 or ballrect.right > SCREEN_SIZE[0]:
            ballspeed[0] = -ballspeed[0]
        if ballrect.top < 0 or ballrect.bottom > SCREEN_SIZE[1]:
            ballspeed[1] = -ballspeed[1]

        screen.fill((0, 0, 0))
        screen.blit(ball, ballrect)

        if ballrect.left < 0:
            ball = BLUE
            # Top left corner
            if ballrect.top < 0:
                corner_score += 1
            # Bottom left corner
            if ballrect.bottom > SCREEN_SIZE[1]:
                corner_score += 1

        if ballrect.right > SCREEN_SIZE[0]:
            ball = GREEN

        if ballrect.top < 0:
            ball = PURPLE
            # Top right corner
            if ballrect.right > SCREEN_SIZE[0]:
                corner_score += 1

        if ballrect.bottom > SCREEN_SIZE[1]:
            ball = YELLOW
            # Bottom Right corner
            if ballrect.right > SCREEN_SIZE[0]:
                corner_score += 1

        # Render score to screen
        score = font.render("Corner Touches: " + str(corner_score), True, (255, 255, 255))
        screen.blit(score, (X, Y))

        pygame.display.update()


if __name__ == '__main__':
    game()
