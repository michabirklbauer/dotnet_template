#!/usr/bin/env python3

# APP - TESTS
# 2024 (c) Micha Johannes Birklbauer
# https://github.com/michabirklbauer/
# micha.birklbauer@gmail.com

def test1():
    import subprocess
    result = subprocess.run(["./App", "--name", "Luna"], stdout = subprocess.PIPE)
    print(f"GOT$\n{result.stdout.decode("utf-8")}$")
    lines = result.stdout.decode("utf-8").split()
    assert len(lines) == 4
    assert lines[0].strip() == "Starting Template App v0.0.1 ..."
    assert lines[1].strip() == "Hello Luna!"
    assert lines[2].strip() == "Successfully greeted Luna!"
    assert lines[3].strip() == "Template App exited!"

def test2():
    import subprocess
    result = subprocess.run(["./App", "--name", "Luna", "--greeting", "Hi"], stdout = subprocess.PIPE)
    print(f"GOT$\n{result.stdout.decode("utf-8")}$")
    lines = result.stdout.decode("utf-8").split()
    assert len(lines) == 4
    assert lines[0].strip() == "Starting Template App v0.0.1 ..."
    assert lines[1].strip() == "Hi Luna!"
    assert lines[2].strip() == "Successfully greeted Luna!"
    assert lines[3].strip() == "Template App exited!"
