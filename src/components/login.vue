<template>
    <form class="login">
        <h1>Studieadministation</h1>

        <div class="form-group-wrapper">
            <div class="form-group">
            <label for="Email">Email</label>
            <input type="text" name="e-mail" id="email" class="form-control" placeholder="">
            </div>

            <div class="form-group">
            <label for="Password">Password</label>
            <input type="password" name="password" id="password" class="form-control" placeholder="">
            </div>

            <div class="form-group-essentiels">
                <div class="inner-form-group">
                    <input type="checkbox" value="lsRememberMe" id="rememberMe"> 
                    <label for="rememberMe">Husk mig</label>
                </div>
                <div class="inner-form-group">
                    <a href="#">Glemt password?</a>
                </div>
                
            </div>

            <button class="button login" type="submit">Login</button>
        </div>
    </form>
</template>

<script>

</script>


<style lang="scss" ></style>