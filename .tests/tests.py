#!/usr/bin/env python3

# APP - TESTS
# 2024 (c) Micha Johannes Birklbauer
# https://github.com/michabirklbauer/
# micha.birklbauer@gmail.com

def test1():
    expected = r"Starting Template App v0.0.1 ...\r\nHello Luna!\r\nSuccessfully greeted Luna!\r\nTemplate App exited!\r\n"

    import subprocess
    result = subprocess.run(["App", "--name", "Luna"], stdout = subprocess.PIPE)
    print(f"GOT${result.stdout.decode("utf-8")}$")
    assert result.stdout.decode("utf-8") == expected

def test2():
    expected = r"Starting Template App v0.0.1 ...\r\nHi Luna!\r\nSuccessfully greeted Luna!\r\nTemplate App exited!\r\n"

    import subprocess
    result = subprocess.run(["App", "--name", "Luna", "--greeting", "Hi"], stdout = subprocess.PIPE)
    print(f"GOT${result.stdout.decode("utf-8")}$")
    assert result.stdout.decode("utf-8") == expected
